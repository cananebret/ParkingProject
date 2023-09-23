using ParkingProject.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingProject.ServiceLayer.Interfaces
{
    public interface ICarParkService
    {
        IQueryable<CarParkListModel> GetCarParks();
        IQueryable<CarParkListModel> GetCarParksByType(string type);
        ServiceResult AddCarToPark(CarParkListModel model);
        ServiceResult CalculateCarParkAmount(string numberPlate);
    }
}
