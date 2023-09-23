using ParkingProject.DataLayer.Context;
using ParkingProject.DataLayer.Entities;
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
    public class ParkingInfoRepository : IParkingInfoRepository
    {
        private readonly ParkingContext _context;

        public ParkingInfoRepository(ParkingContext context)
        {
            _context = context;
        }

        public ServiceResult AddParkingInfo()
        {
            ServiceResult serviceResult = new ServiceResult { StatusCode = HttpStatusCode.OK };

            _context.ParkingInfos.Add(new ParkingInfo
            {
                OpeningDate = new DateTime(2023, 01, 01, 06, 00, 00),
                ClosingDate = new DateTime(2023, 01, 01, 23, 59, 00),
                HourlyWage = 25,
                IsActive = true,
                Deleted = false,
            });

            _context.SaveChanges();

            return serviceResult;
        }
    }
}
