using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingProject.DataLayer.Entities
{
    public class ParkingInfo : BaseInfoEntity
    {
        public DateTime OpeningDate { get; set; }
        public DateTime ClosingDate { get; set; }
        public decimal HourlyWage { get; set; }
    }
}
