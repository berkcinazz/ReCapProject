using Business.Abstract;
using Entities.Concrete;
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
    public class CustomersController : ControllerBase
    {
        ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpGet("getall")]
        public IActionResult GetAllCustomers()
        {
            var result = _customerService.GetAllCustomer();
            return StatusCode(result.Success ? 200 :400 ,result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetCustomerById(int id)
        {
            var result = _customerService.GetCustomerById(id);
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpPost]
        public IActionResult AddCustomer(CustomerForAddDto customer)
        {
            var result = _customerService.AddCustomer(customer);
            return StatusCode(result.Success ? 200 : 400, result);
        }
    }
}
