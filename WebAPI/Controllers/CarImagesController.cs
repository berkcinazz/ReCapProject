using Business.Abstract;
using Business.Constants;
using Entities.Concrete;
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
        IWebHostEnvironment _webHostEnvironment;
        public CarImagesController(ICarImagesService carImagesService, IWebHostEnvironment webHostEnvironment)
        {
            _carImagesService = carImagesService;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImagesService.GetAllImages();
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add([FromForm] CarImage carImage, IFormFile image)
        {
            try
            {
                string path = DefaultRoutes.DefaultImageFolder;
                string fileNameWithGUID = $"{Guid.NewGuid().ToString()}{Path.GetExtension(image.FileName)}";

                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                using (FileStream fileStream = System.IO.File.Create(Path.Combine(path, fileNameWithGUID)))
                {
                    image.CopyTo(fileStream);
                    fileStream.Flush();
                }
                carImage.ImagePath = Path.Combine(path, fileNameWithGUID);
                var result = _carImagesService.AddImage(carImage);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        [HttpPost("update")]
        public IActionResult Update([FromForm] CarImage carImage, IFormFile image)
        {
            try
            {
                string path = DefaultRoutes.DefaultImageFolder;
                string fileNameWithGUID = $"{Guid.NewGuid().ToString()}{Path.GetExtension(image.FileName)}";
                var iresult = _carImagesService.GetAllImages().Data.Where(c => c.Id == carImage.Id).Any();

                if (iresult)
                {
                    if (!System.IO.File.Exists(carImage.ImagePath))
                    {
                        throw new FileNotFoundException();
                    }
                    System.IO.File.Delete(carImage.ImagePath);
                    using (FileStream fileStream = System.IO.File.Create(Path.Combine(path, fileNameWithGUID)))
                    {
                        image.CopyTo(fileStream);
                        fileStream.Flush();
                    }
                    carImage.ImagePath = Path.Combine(path, fileNameWithGUID);
                    var result = _carImagesService.UpdateImage(carImage);
                    if (result.Success)
                    {
                        return Ok(result);
                    }
                    return BadRequest(result);
                }
                return BadRequest(iresult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }

        [HttpPost("delete")]
        public IActionResult Delete([FromForm] CarImage carImage)
        {
            try
            {
                if (!System.IO.File.Exists(carImage.ImagePath))
                {
                    throw new FileNotFoundException();
                }
                System.IO.File.Delete(carImage.ImagePath);

                var result = _carImagesService.DeleteImage(carImage);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}
