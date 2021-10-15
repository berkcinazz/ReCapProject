using Core.DataAccess;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDalManager : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDalManager()
        {
            _cars = new List<Car>
            {
                new Car{CarId=1,BrandId=1,ColorId=1,DailyPrice=585,ModelYear=2020,Description="If u wanna some speed choose this one."},
                new Car{CarId=2,BrandId=2,ColorId=2,DailyPrice=415,ModelYear=2010,Description="Could be bad choose."},
                new Car{CarId=3,BrandId=3,ColorId=3,DailyPrice=450,ModelYear=2012,Description="Good choose."},
                new Car{CarId=4,BrandId=4,ColorId=4,DailyPrice=125,ModelYear=2008,Description="So old car. Don't pick up."},
                new Car{CarId=5,BrandId=5,ColorId=2,DailyPrice=150,ModelYear=2015,Description="It was never selected"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public List<CarDetailDto> CarDetails(int carId)
        {
            throw new NotImplementedException();
        }

        public void Delete(Car car)
        {
            _cars.Remove(_cars.FirstOrDefault(c => c.CarId == car.CarId));
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.CarId == carId).ToList();
        }

        public void Update(Car car)
        {
            Car updatedCars = _cars.SingleOrDefault(c =>c.CarId == car.CarId);
            car.CarId = updatedCars.CarId;
            car.ColorId = updatedCars.ColorId;
            car.BrandId = updatedCars.BrandId;
            car.DailyPrice = updatedCars.DailyPrice;
            car.ModelYear = updatedCars.ModelYear;
            car.Description = updatedCars.Description;
        }

        
    }
}
