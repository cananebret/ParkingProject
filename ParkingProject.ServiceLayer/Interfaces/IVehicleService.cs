
using ParkingProject.DataLayer.Entities;
using ParkingProject.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingProject.ServiceLayer.Interfaces
{
    public interface IVehicleService
    {
        IQueryable<Vehicle> GetAll();

        ServiceResult Post(VehiclePostModel model);
        ServiceResult Put(VehiclePutModel model);

        ServiceResult CalculateHorsePower(HorsePowerModel model);
    }
}
