using Microsoft.EntityFrameworkCore;
using ParkingProject.DataLayer.Enums;
using ParkingProject.DataLayer.Interfaces;
using ParkingProject.DataLayer.Models;
using ParkingProject.ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingProject.ServiceLayer.Services
{
    public class CarParkService : ICarParkService
    {
        private readonly ICarParkRepository _carParkRepository;

        public CarParkService(ICarParkRepository carParkRepository)
        {
            _carParkRepository = carParkRepository;
        }

        public IQueryable<CarParkListModel> GetCarParks()
        {
            return _carParkRepository.GetCarParks();
        }

        public IQueryable<CarParkListModel> GetCarParksByType(string type)
        {
            return _carParkRepository.GetCarParksByType(type);
        }

        public ServiceResult AddCarToPark(CarParkListModel model)
        {
            return _carParkRepository.AddCarToPark(model);
        }

        public ServiceResult CalculateCarParkAmount(string numberPlate)
        {
            return _carParkRepository.CalculateCarParkAmount(numberPlate);
        }
    }
}
