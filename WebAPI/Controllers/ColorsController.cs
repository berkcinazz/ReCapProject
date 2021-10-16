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
    public class ColorsController : ControllerBase
    {
        IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }
        [HttpGet("getall")]
        public IActionResult GetAllColors()
        {
            var result = _colorService.GetAllColor();
            return StatusCode(result.Success ? 200 : 400,result);
        }
        [HttpGet("getbyid")]
        public IActionResult GetColorById(int id)
        {
            var result = _colorService.GetColorById(id);
            return StatusCode(result.Success ? 200 : 400, result);
        }
        [HttpPost]
        public IActionResult AddColor(ColorForAddDto color)
        {
            var result = _colorService.AddColor(color);
            return StatusCode(result.Success ? 200 : 400, result);
        }
    }
}
