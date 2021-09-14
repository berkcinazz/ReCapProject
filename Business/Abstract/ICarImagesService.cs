using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImagesService
    {
        IResult AddImage(CarImageForAddDto carImageForAddDto);
        IResult DeleteImage(int carImageId);
        IResult UpdateImage(CarImageForUpdateDto carImageForUpdateDto);
        IDataResult<List<CarImage>> GetAllImages();
    }
}
