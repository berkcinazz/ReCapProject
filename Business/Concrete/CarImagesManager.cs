using Business.Abstract;
using Business.Constants;
using Core.Utilities.BusinessRules;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImagesManager : ICarImagesService
    {
        ICarDal _carDal;

        public CarImagesManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult AddImage(CarImage carImage)
        {
            BusinessRules.Run(CheckIfLimitOfCarImage(carImage.CarId));
            return new SuccessResult(Messages.ImagesAdded);
        }

        public IResult DeleteImage(CarImage image)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarImage>> GetAllImages()
        {
            throw new NotImplementedException();
        }

        public IResult UpdateImage(CarImage image)
        {
            throw new NotImplementedException();
        }

        private IResult CheckIfLimitOfCarImage(int carId)
        {
            var result = _carDal.GetAll(c=>c.CarId==carId).Count;
            if (result<=5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }
            return new SuccessResult();
        } 
    }
}
