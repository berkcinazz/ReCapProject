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
    public class BrandsController : ControllerBase
    {
        IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }
        [HttpGet("getall")]
        public IActionResult GetAllBrands()
        {
            var result = _brandService.GetAllBrand();
            return StatusCode(result.Success ? 200 : 400,result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetBrandById(int id)
        {
            var result = _brandService.GetBrandById(id);
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpPost]
        public IActionResult AddBrand(BrandForAddDto brand)
        {
            var result = _brandService.AddBrand(brand);
            return StatusCode(result.Success ? 200 : 400 ,result);
        }
    }
}
