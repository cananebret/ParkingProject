using ParkingProject.DataLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingProject.DataLayer.Models
{
    public class CarParkListModel
    {
        [Description("Araç Tipi")]
        public VehicleTypes Type { get; set; }

        [Description("Plaka")]
        public string NumberPlate { get; set; }

        [Description("Model Yılı")]
        public string? ModelYear { get; set; }

        [Description("Model Adı")]
        public string? ModelName { get; set; }

        [Description("Renk")]
        public string? Color { get; set; }

        [Description("Açıklama")]
        public string? Description { get; set; }

        [Description("Giriş Tarihi")]
        public DateTime StartDate { get; set; }

        [Description("Çıkış Tarihi")]
        public DateTime? EndDate { get; set; }

        [Description("Kalma Süresi")]
        public DateTime? StayDate { get; set; }

        [Description("Tutar")]
        public decimal? Amount { get; set; }
    }
}
