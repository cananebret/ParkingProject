using Microsoft.EntityFrameworkCore;
using ParkingProject.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingProject.DataLayer.Context
{
    public class ParkingContext : DbContext
    {
        public ParkingContext() : base()
        {
            ChangeTracker.AutoDetectChangesEnabled = true;
        }
        public ParkingContext(DbContextOptions options) : base(options)
        {
            ChangeTracker.AutoDetectChangesEnabled = true;
        }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<CarPark> CarParks { get; set; }
        public DbSet<ParkingInfo> ParkingInfos { get; set; }
    }
}
