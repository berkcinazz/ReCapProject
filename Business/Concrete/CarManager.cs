using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
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

        public void AddCar(Car car)
        {
            if (car.Description.Length >= 2)
            {
                if (car.DailyPrice > 0)
                {
                    _carDal.Add(car);

                }
                else
                {
                    Console.WriteLine("Günlük fiyatı 0'dan büyük olmalıdır.");
                }
            }
            else
            {
                Console.WriteLine("Açıklama uzunluğu minimum 2 olmalıdır.");
            }
        }

        public void DeleteCar(Car car)
        {
            _carDal.Delete(car);

        }

        public List<Car> GetAllCars()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetCarsByBrandId(int brandId)
        {
            return _carDal.GetAll(c => c.BrandId == brandId).ToList();
        }

        public List<Car> GetCarsByColorId(int colorId)
        {
            return _carDal.GetAll(c=>c.ColorId==colorId).ToList();
        }

        public List<Car> GetCarsById(int carId)
        {
            return _carDal.GetAll(c => c.CarId == carId);
                

        }

        public void UpdateCar(Car car)
        {
            _carDal.Update(car);
            Console.WriteLine(car.ModelYear + " yılındaki araç güncellendi");

        }
    }
}
