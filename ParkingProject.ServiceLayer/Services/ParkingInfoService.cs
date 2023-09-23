using Microsoft.EntityFrameworkCore;
using ParkingProject.DataLayer.Entities;
using ParkingProject.DataLayer.Interfaces;
using ParkingProject.DataLayer.Models;
using ParkingProject.ServiceLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ParkingProject.ServiceLayer.Services
{
    public class ParkingInfoService : IParkingInfoService
    {
        private readonly IParkingInfoRepository _parkingInfoRepository;

        public ParkingInfoService(IParkingInfoRepository parkingInfoRepository)
        {
            _parkingInfoRepository = parkingInfoRepository;
        }
        public ServiceResult AddParkingInfo()
        {
            return _parkingInfoRepository.AddParkingInfo();
        }
    }
}
