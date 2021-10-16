using Core.DataAccess;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAllCars();
        IDataResult<Car> GetCarsById(int carId);
        IDataResult<List<Car>> GetCarsByBrandId(int brandId);
        IDataResult<List<Car>> GetCarsByColorId(int colorId);

        IDataResult<List<CarDetailDto>> GetAllCarsDetail();
        IResult AddCar(CarForAddDto car);
        IResult DeleteCar(int carId);
        IResult UpdateCar(Car car);
        IDataResult<List<CarDetailDto>> GetCarDetails(int carId);

    }
}
