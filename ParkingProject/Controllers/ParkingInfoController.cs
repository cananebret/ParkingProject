using Microsoft.AspNetCore.Mvc;
using ParkingProject.DataLayer.Entities;
using ParkingProject.DataLayer.Models;
using ParkingProject.ServiceLayer.Interfaces;
using ParkingProject.ServiceLayer.Services;

namespace ParkingProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkingInfoController : Controller
    {
        private readonly IParkingInfoService _parkingInfoService;

        public ParkingInfoController(IParkingInfoService parkingInfoService)
        {
            _parkingInfoService = parkingInfoService;
        }

        [HttpPost("AddParkingInfo")]
        public IActionResult AddParkingInfo()
        {
            var result = _parkingInfoService.AddParkingInfo();
            return Ok(result);
        }
    }
}
