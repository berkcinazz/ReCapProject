using Business.Abstract;
using Business.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public IResult AddCar(CarForAddDto car)
        {
            Car carToAdd = new Car()
            {
                BrandId = car.BrandId,
                ColorId = car.ColorId,
                DailyPrice = car.DailyPrice,
                Description = car.Description,
                ModelYear = car.ModelYear
            };
            if (car.Description.Length >= 2)
            {
                if (car.DailyPrice > 0)
                {
                    _carDal.Add(carToAdd);
                    return new SuccessResult(Messages.ItemAdded);
                }
                else
                {
                    return new ErrorResult("Günlük fiyatı 0'dan büyük olmalıdır.");
                }
            }
            else
            {
                return new SuccessResult("Açıklama uzunluğu minimum 2 olmalıdır.");
            }
        }

        public IResult DeleteCar(int carId)
        {
            var result = _carDal.Get(c=>c.CarId==carId);
            if (result == null) return new ErrorResult(Messages.CarNotFound);
            _carDal.Delete(result);
            return new SuccessResult(Messages.CarDeleted);
        }
        [CacheAspect]
        public IDataResult<List<Car>>GetAllCars()
        {
            var result = _carDal.GetAll();
            return new SuccessDataResult<List<Car>>(result);
        }
        [CacheAspect]
        public IDataResult<List<CarDetailDto>> GetAllCarsDetail()
        {
            var result = _carDal.GetAllCarDetails();
            return new SuccessDataResult<List<CarDetailDto>>(result);
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails(int carId)
        {
            var result = _carDal.CarDetails(carId);
            return new SuccessDataResult<List<CarDetailDto>>(result);
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            var result = _carDal.GetAll(c => c.BrandId == brandId).ToList();
            return new SuccessDataResult<List<Car>>(result);
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            var result = _carDal.GetAll(c => c.ColorId == colorId).ToList();
            return new SuccessDataResult<List<Car>>(result);
        }

        public IDataResult<Car> GetCarsById(int carId)
        {
            var result = _carDal.Get(c => c.CarId == carId);
            return new SuccessDataResult<Car>(result);
        }

        public IResult UpdateCar(Car car)
        {
            var result = _carDal.Get(c=>c.CarId==car.CarId);
            if (result == null) return new ErrorResult(Messages.CarNotFound);
            result.CarId = car.CarId;
            result.ColorId = car.ColorId;
            result.Description = car.Description;
            result.DailyPrice = car.DailyPrice;
            result.Description = car.Description;
            result.BrandId = car.BrandId;
            _carDal.Update(result);
            return new SuccessResult(car.ModelYear + " yılındaki araç güncellendi");

        }

    }
}
