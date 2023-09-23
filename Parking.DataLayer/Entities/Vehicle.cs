using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingProject.DataLayer.Entities
{
    public class Vehicle : BaseInfoEntity
    {
        public int Type { get; set; }
        public string Description { get; set; }
        public bool IsCarWashing { get; set; }
        public bool IsTireChanging { get; set; }
        public bool HasAutoPilot{ get; set; }
        public bool HasAmount{ get; set; }
        public bool HasTrunkVolume{ get; set; }
        public bool HasSpareTyre{ get; set; }
        public decimal WageCoefficient{ get; set; }
    }
}
