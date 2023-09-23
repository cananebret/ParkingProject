using ParkingProject.DataLayer.Context;
using ParkingProject.DataLayer.Entities;
using ParkingProject.DataLayer.Enums;
using ParkingProject.DataLayer.Interfaces;
using ParkingProject.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ParkingProject.DataLayer.Repositories
{
    public class CarParkRepository : ICarParkRepository
    {
        private readonly ParkingContext _context;
        public CarParkRepository(ParkingContext context)
        {
            _context = context;
        }

        public IQueryable<CarParkListModel> GetCarParks()
        {
            var list = _context.CarParks.Where(i => !i.Deleted && i.IsActive)
                .Select(i => new CarParkListModel
                {
                    NumberPlate = i.NumberPlate,
                    StartDate = i.StartDate,
                    EndDate = i.EndDate,
                    Description = i.Description,
                    ModelName = i.ModelName,
                    ModelYear = i.ModelYear,
                    Type = (VehicleTypes)i.TypeId,
                    Amount = i.Amount
                });

            return list;
        }

        public IQueryable<CarParkListModel> GetCarParksByType(string type)
        {
            var list = _context.CarParks.Where(i => !i.Deleted && i.IsActive && i.TypeId == Convert.ToInt32(type))
                .Select(i => new CarParkListModel
                {
                    NumberPlate = i.NumberPlate,
                    StartDate = i.StartDate,
                    EndDate = i.EndDate,
                    Description = i.Description,
                    ModelName = i.ModelName,
                    ModelYear = i.ModelYear,
                    Type = (VehicleTypes)i.TypeId,
                    Amount = i.Amount
                });

            return list;
        }

        public ServiceResult AddCarToPark(CarParkListModel model)
        {
            ServiceResult serviceResult = new ServiceResult { StatusCode = HttpStatusCode.OK };

            var openingHour = _context.ParkingInfos.FirstOrDefault(i => !i.Deleted && i.IsActive)?.OpeningDate;

            if (openingHour.Value.Hour > model.StartDate.Hour)
            {
                serviceResult.Message = "Otopark açılmadı";
                serviceResult.StatusCode = HttpStatusCode.NotFound;
            }

            else
            {
                CarPark carPark = new CarPark
                {
                    NumberPlate = model.NumberPlate,
                    TypeId = (int)model.Type,
                    StartDate = DateTime.Now,
                    Color = model.Color,
                    ModelName = model.ModelName,
                    ModelYear = model.ModelYear,
                    Description = model.Description,
                    Deleted = false,
                    IsActive = true,
                    StayDate = model.StayDate
                };

                _context.CarParks.Add(carPark);
                _context.SaveChanges();
            }

            return serviceResult;
        }

        public ServiceResult CalculateCarParkAmount(string numberPlate)
        {
            ServiceResult serviceResult = new ServiceResult { StatusCode = HttpStatusCode.OK };

            var openingHour = _context.ParkingInfos.FirstOrDefault(i => !i.Deleted && i.IsActive)?.OpeningDate;
            var currentDate = DateTime.Now;

            if (openingHour != null && openingHour.Value.Hour > currentDate.Hour)
            {
                serviceResult.Message = "Otopark kapanmıştır";
                serviceResult.StatusCode = HttpStatusCode.NotFound;
            }

            var car = _context.CarParks.FirstOrDefault(i => !i.IsOut && i.NumberPlate == numberPlate);

            if (car == null)
            {
                serviceResult.Message = "Araç bulunamadı.";
                serviceResult.StatusCode = HttpStatusCode.NotFound;
            }

            else
            {
                var hourlyAmount = _context.ParkingInfos.FirstOrDefault(i => !i.Deleted && i.IsActive)?.HourlyWage;
                var carAmount = _context.Vehicles.FirstOrDefault(i => i.Type == car.TypeId)?.WageCoefficient;

                var totalDate = (DateTime.Now - car.StartDate).TotalHours;

                var totalAmount = hourlyAmount * carAmount * Convert.ToDecimal(totalDate);

                if (totalAmount == null)
                {
                    serviceResult.Message = "Ücret hesaplanamadı.";

                }
                if (totalAmount.HasValue)
                {
                    serviceResult.Message = $"Ödenecek Ücret : {Math.Round(totalAmount.Value, 2)}";

                    car.IsOut = true;
                    car.EndDate = DateTime.Now;
                    _context.SaveChanges();
                }
            }

            return serviceResult;
        }
    }
}
