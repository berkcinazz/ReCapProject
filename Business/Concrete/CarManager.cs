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

        public IResult AddCar(Car car)
        {
            if (car.Description.Length >= 2)
            {
                if (car.DailyPrice > 0)
                {
                    _carDal.Add(car);
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

        public IResult DeleteCar(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult("Araç silindi");
        }
        [CacheAspect]
        public IDataResult<List<Car>>GetAllCars()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(),"Tebrikler. Tüm arabaları listelediniz");
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails(int carId)
        {
            return new SuccessDataResult<List<CarDetailDto>>(_carDal.CarDetails(carId),"Tebrikler. Seçmiş olduğunuz arabanın detaylarını listelediniz");
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == brandId).ToList());
        }

        public IDataResult<List<Car>> GetCarsByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c=>c.ColorId==colorId).ToList());
        }

        public IDataResult<Car> GetCarsById(int carId)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carId),"");
        }

        public IResult UpdateCar(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(car.ModelYear + " yılındaki araç güncellendi");

        }

    }
}
