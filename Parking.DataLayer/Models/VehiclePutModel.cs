using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingProject.DataLayer.Models
{
    public class VehiclePutModel
    {
        public int Type { get; set; }
        public string? Description { get; set; }
        public decimal WageCoefficient { get; set; }
    }
}
