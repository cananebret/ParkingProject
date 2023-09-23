using Microsoft.AspNetCore.Mvc;
using ParkingProject.DataLayer.Models;
using ParkingProject.ServiceLayer.Interfaces;

namespace ParkingProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParkingController : ControllerBase
    {
        private readonly ICarParkService _carParkService;
        public ParkingController(ICarParkService carParkService)
        {
            _carParkService = carParkService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _carParkService.GetCarParks();
            return Ok(result);
        }

        [HttpGet("GetAllByType/{type}")]
        public IActionResult GetAllByType(string type)
        {
            var result = _carParkService.GetCarParksByType(type);
            return Ok(result);
        }

        [HttpPost("AddCarToPark")]
        public IActionResult AddCarToPark(CarParkListModel model)
        {
            var result = _carParkService.AddCarToPark(model);
            return Ok(result);
        }

        [HttpPost("CalculateParkAmount")]
        public IActionResult CalculateParkAmount([FromBody] CalculateParkAmountModel model)
        {
            var result = _carParkService.CalculateCarParkAmount(model.numberPlate);
            return Ok(result);
        }
    }
}
