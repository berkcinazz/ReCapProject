using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;
        public CarsController(ICarService carService)
        {
            _carService = carService;
        }
        [HttpGet("getall")]
        //[Authorize(Roles = "Car.List")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAllCars();
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpGet("getallcarsdetail")]
        public IActionResult GetAllCarsDetail()
        {
            var result = _carService.GetAllCarsDetail();
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpGet("getcarsbycolorid")]
        public IActionResult GetCarsByColorId(int colorId)
        {
            var result = _carService.GetCarsByColorId(colorId);
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpGet("getcarsbybrandid")]
        public IActionResult GetCarsByBrandId(int brandId)
        {
            var result = _carService.GetCarsByBrandId(brandId);
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpGet("getcarbyid")]
        public IActionResult GetCarById(int carId)
        {
            var result = _carService.GetCarsById(carId);
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpPut]
        public IActionResult UpdateCar(Car car)
        {
            var result = _carService.UpdateCar(car);
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpDelete]
        public IActionResult DeleteCar(int carId)
        {
            var result = _carService.DeleteCar(carId);
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpPost]
        public IActionResult AddCar(CarForAddDto car)
        {
            var result = _carService.AddCar(car);
            return StatusCode(result.Success ? 200 : 400, result);
        }
    }
}
