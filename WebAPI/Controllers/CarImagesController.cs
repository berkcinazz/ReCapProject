using Business.Abstract;
using Business.Constants;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        ICarImagesService _carImagesService;
        public CarImagesController(ICarImagesService carImagesService)
        {
            _carImagesService = carImagesService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImagesService.GetAllImages();
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpPost("add")]
        public IActionResult Add([FromForm] CarImageForAddDto carImageForAddDto)
        {
            var result = _carImagesService.AddImage(carImageForAddDto);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpPut("update")]
        public IActionResult Update([FromForm] CarImageForUpdateDto carImageForUpdateDto)
        {
            var result = _carImagesService.UpdateImage(carImageForUpdateDto);
            return StatusCode(result.Success ? 200 : 400, result);
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromForm] int carImageId)
        {
            var result = _carImagesService.DeleteImage(carImageId);
            return StatusCode(result.Success ? 200: 400, result);
        }
    }
}
