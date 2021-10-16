using Business.Abstract;
using Entities.DTOs;
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
    public class RentalsController : ControllerBase
    {
        IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }
        [HttpGet("getallrental")]
        public IActionResult GetallRental()
        {
            var result = _rentalService.GetAllRental();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getallrentaldetails")]
        public IActionResult GetallRentalDetails()
        {
            var result = _rentalService.GetAllRentalsDetail();
            return StatusCode(result.Success ? 200 : 400,result);
        }
        [HttpGet("getrentalbyid")]
        public IActionResult GetRentalById(int rentalId)
        {
            var result = _rentalService.GetRentalById(rentalId);
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpPost]
        public IActionResult AddRental(RentalForAddDto rental)
        {
            var result = _rentalService.AddRental(rental);
            return StatusCode(result.Success ? 200 : 400, result);
        }
    }
}
