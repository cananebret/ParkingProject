
using ParkingProject.DataLayer.Entities;
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
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository _vehicleRepository;

        public VehicleService(IVehicleRepository vehicleRepository)
        {
            _vehicleRepository = vehicleRepository;
        }

        public IQueryable<Vehicle> GetAll()
        {
            return _vehicleRepository.GetAll();
        }

        public ServiceResult Post(VehiclePostModel model)
        {
            return _vehicleRepository.Post(model);

        }

        public ServiceResult Put(VehiclePutModel model)
        {
            return _vehicleRepository.Put(model);

        }

        public ServiceResult CalculateHorsePower(HorsePowerModel model)
        {
            return _vehicleRepository.CalculateHorsePower(model);

        }
    }
}
