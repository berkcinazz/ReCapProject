using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarImagesService
    {
        IResult AddImage(CarImage image);
        IResult DeleteImage(CarImage image);
        IResult UpdateImage(CarImage image);
        IDataResult<List<CarImage>> GetAllImages();
    }
}
