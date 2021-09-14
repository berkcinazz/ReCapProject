using Business.Abstract;
using Business.Constants;
using Core.Utilities.BusinessRules;
using Core.Utilities.Helpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImagesManager : ICarImagesService
    {
        ICarImagesDal _carImagesDal;
        public CarImagesManager(ICarImagesDal carImagesDal)
        {
            _carImagesDal = carImagesDal;
        }

        public IResult AddImage(CarImageForAddDto carImageForAddDto)
        {
            var businessRulesResult = BusinessRules.Run(CheckIfLimitOfCarImage(carImageForAddDto.CarId));
            if (businessRulesResult != null)
                return businessRulesResult;
            CarImage carImage = new CarImage()
            {
                CarId = carImageForAddDto.CarId,
                ImagePath = FileHelper.UploadImage(carImageForAddDto.Image),
                Date = DateTime.Now
            };
            _carImagesDal.Add(carImage);
            return new SuccessResult(Messages.ImagesAdded);
        }


        public IResult DeleteImage(int carImageId)
        {
            var result = _carImagesDal.Get(c => c.Id == carImageId);
            if (result == null)
            {
                return new ErrorResult(Messages.ImageNotFound);
            }
            _carImagesDal.Delete(result);
            FileHelper.DeleteImage(result.ImagePath);
            return new SuccessResult(Messages.DeleteImageSuccess);
        }

        public IDataResult<List<CarImage>> GetAllImages()
        {
            throw new NotImplementedException();
        }
        public IResult UpdateImage(CarImageForUpdateDto carImageForUpdateDto)
        {
            var result = _carImagesDal.Get(c=>c.Id== carImageForUpdateDto.ImageId);
            if (result==null)
            {
                return new ErrorResult(Messages.ImageNotFound);
            }
            FileHelper.DeleteImage(result.ImagePath);
            result.CarId = carImageForUpdateDto.CarId;
            result.Date = DateTime.Now;
            result.ImagePath = FileHelper.UploadImage(carImageForUpdateDto.Image);
            _carImagesDal.Update(result);

            return new SuccessResult(Messages.ImageUpdateSuccessfull);
        }

        private IResult CheckIfLimitOfCarImage(int carId)
        {
            var result = _carImagesDal.GetAll(c=>c.CarId==carId).Count;
            if (result>=5)
            {
                return new ErrorResult(Messages.CarImageLimitExceeded);
            }
            return new SuccessResult();
        } 
    }
}
