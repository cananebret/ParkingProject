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
    public class VehicleRepository : IVehicleRepository
    {

        ParkingContext _context;
        public VehicleRepository(ParkingContext context)
        {
            _context = context;
        }

        public IQueryable<Vehicle> GetAll()
        {
            return _context.Vehicles.Where(i => !i.Deleted && i.IsActive);
        }

        public ServiceResult Post(VehiclePostModel model)
        {
            ServiceResult serviceResult = new ServiceResult { StatusCode = HttpStatusCode.OK };

            if (model.Type == null)
            {
                serviceResult.Message = "Araç tipi boş olamaz";
                serviceResult.StatusCode = HttpStatusCode.NotFound;
            }

            var typeExist = _context.Vehicles.Any(i => i.Type == model.Type);

            if (typeExist)
            {
                serviceResult.Message = "Araç tipi tanımlıdır. Aynı araç tipinden ekleyemezsiniz";
                serviceResult.StatusCode = HttpStatusCode.Found;
            }

            else if (!Enum.IsDefined(typeof(VehicleTypes), model.Type))
            {
                serviceResult.Message = "Araç tipi tanımlı değildir. Kontrol ediniz";
                serviceResult.StatusCode = HttpStatusCode.NotFound;
            }

            else
            {
                var vehicle = new Vehicle
                {
                    Type = model.Type,
                    Description = model.Description,
                    IsCarWashing = model.Type == (int)VehicleTypes.FirstClass ? true : false,
                    HasAutoPilot = model.Type == (int)VehicleTypes.FirstClass ? true : false,
                    HasAmount = model.Type == (int)VehicleTypes.FirstClass ? true : false,
                    IsTireChanging = model.Type == (int)VehicleTypes.SecondClass ? true : false,
                    HasTrunkVolume = model.Type == (int)VehicleTypes.SecondClass ? true : false,
                    HasSpareTyre = model.Type == (int)VehicleTypes.SecondClass ? true : false,
                    IsActive = true
                };

                _context.Vehicles.Add(vehicle);
                _context.SaveChanges();
            }

            return serviceResult;
        }

        public ServiceResult Put(VehiclePutModel model)
        {
            ServiceResult serviceResult = new ServiceResult { StatusCode = HttpStatusCode.OK };

            if (model.Type == null)
            {
                serviceResult.Message = "Araç tipi boş olamaz";
                serviceResult.StatusCode = HttpStatusCode.NotFound;
            }

            var vehicle = _context.Vehicles.FirstOrDefault(i => i.Type == model.Type);

            if (vehicle == null)
            {
                serviceResult.Message = "Araç tipi bulunamadı.";
                serviceResult.StatusCode = HttpStatusCode.NotFound;
            }

            else if (!Enum.IsDefined(typeof(VehicleTypes), model.Type))
            {
                serviceResult.Message = "Araç tipi tanımlı değildir. Kontrol ediniz";
                serviceResult.StatusCode = HttpStatusCode.NotFound;
            }

            else
            {
                vehicle.WageCoefficient = model.WageCoefficient;

                if (!string.IsNullOrWhiteSpace(model.Description))
                    vehicle.Description = model.Description;

                _context.SaveChanges();
            }

            return serviceResult;
        }

        public ServiceResult CalculateHorsePower(HorsePowerModel model)
        {
            ServiceResult serviceResult = new ServiceResult { StatusCode = HttpStatusCode.OK };

            if (model.Tork == null)
            {
                serviceResult.Message = "Tork boş olamaz";
                serviceResult.StatusCode = HttpStatusCode.NotFound;
            }

            if (model.EngineSpeed == null)
            {
                serviceResult.Message = "Motor gübü boş olamaz";
                serviceResult.StatusCode = HttpStatusCode.NotFound;
            }

            else
            {
                var power = (model.Tork * model.EngineSpeed) / 5252;

                serviceResult.Message = $"Beygir Gücü : {Math.Round(power, 2)}"; 
            }

            return serviceResult;

        }
    }
}
