using Business.Concrete;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            CarManager carManagerr = new CarManager(new EfCarDal());
            foreach (var item in carManagerr.GetCarDetails(1))
            {
                Console.WriteLine("{0}/{1}/{2}",item.BrandName,item.ColorName,item.Description);

            }
            //CarTest();
        }

        private static void CarTest()
        {
            Car car = new Car { CarId = 1, BrandId = 2, ColorId = 3, DailyPrice = 8000, ModelYear = 2021, Description = "Ferrari" };

            CarManager carManager = new CarManager(new EfCarDal());
            //carManager.AddCar(car);
            //carManager.DeleteCar(car);
            foreach (var carr in carManager.GetAllCars())
            {
                Console.WriteLine(carr.Description + " isimli araba");
            }
            foreach (var car1 in carManager.GetCarsByBrandId(2))
            {
                Console.WriteLine("Seçtiğiniz araba marka idsine sahip arabalar : " + car1.Description);
            }
            foreach (var car1 in carManager.GetCarsByColorId(2))
            {
                Console.WriteLine("Seçtiğiniz araba renk idsine sahip arabalar: " + car1.Description);
            }
            foreach (var car1 in carManager.GetCarsById(1))
            {
                Console.WriteLine("Seçtiğiniz araba idsine göre araba : " + car1.Description);
            }

            //carManager.UpdateCar(car);
            Console.WriteLine("Hello World!");
        }
    }
}
