using Core.Entities;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CarImageForUpdateDto:IDto
    {
        public int CarId { get; set; }
        public int ImageId { get; set; }
        public IFormFile Image { get; set; }
    }
}
