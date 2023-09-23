using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingProject.DataLayer.Entities
{
    public class CarPark : BaseInfoEntity
    {
        public int TypeId { get; set; }
        public string NumberPlate { get; set; }
        public string? ModelYear { get; set; }
        public string? ModelName { get; set; }
        public string? Color { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? StayDate { get; set; }
        public decimal? Amount { get; set; }
        public bool IsOut { get; set; }
    }
}
