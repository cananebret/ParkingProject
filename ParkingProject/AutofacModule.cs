using Autofac;
using ParkingProject.DataLayer.Context;
using ParkingProject.DataLayer.Interfaces;
using ParkingProject.DataLayer.Repositories;
using ParkingProject.ServiceLayer.Interfaces;
using ParkingProject.ServiceLayer.Services;
using System.Reflection;

namespace ParkingProject
{
    public class AutofacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<ParkingContext>();

            containerBuilder.RegisterType<VehicleService>().As<IVehicleService>();
            containerBuilder.RegisterType<VehicleRepository>().As<IVehicleRepository>();

            containerBuilder.RegisterType<CarParkService>().As<ICarParkService>();
            containerBuilder.RegisterType<CarParkRepository>().As<ICarParkRepository>();

            containerBuilder.RegisterType<ParkingInfoService>().As<IParkingInfoService>();
            containerBuilder.RegisterType<ParkingInfoRepository>().As<IParkingInfoRepository>();
        }
    }
}
