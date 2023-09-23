using Microsoft.AspNetCore.Mvc;
using ParkingProject.DataLayer.Models;
using ParkingProject.ServiceLayer.Interfaces;

namespace ParkingProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleService _vehicleService;
        public VehicleController(IVehicleService vehicleService)
        {
            _vehicleService = vehicleService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _vehicleService.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post(VehiclePostModel model)
        {
            var result = _vehicleService.Post(model);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Put(VehiclePutModel model)
        {
            var result = _vehicleService.Put(model);
            return Ok(result);
        }

        [HttpGet("GetHorsePower")]
        public IActionResult GetHorsePower(HorsePowerModel model)
        {
            var result = _vehicleService.CalculateHorsePower(model);
            return Ok(result);
        }
    }
}
