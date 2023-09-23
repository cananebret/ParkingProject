using ParkingProject.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingProject.DataLayer.Interfaces
{
    public interface IParkingInfoRepository
    {
        ServiceResult AddParkingInfo();
    }
}
