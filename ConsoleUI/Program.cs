using Business.Concrete;
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
            Car car = new Car { CarId = 1, BrandId = 1, ColorId = 1, DailyPrice = 585, ModelYear = 2020, Description = "If u wanna some speed choose this one." };

            CarManager carManager = new CarManager(new InMemoryCarDalManager());
            carManager.AddCar(car);
            carManager.DeleteCar(car);
            foreach (var carr in carManager.GetAllCars())
            {
                Console.WriteLine(carr.CarId + " Id'li araba");
            }
            foreach (var car1 in carManager.GetCarsById(2))
            {
                Console.WriteLine("Seçtiğiniz arabanın günlük fiyatı: " + car1.DailyPrice);
            }
            carManager.UpdateCar(car);
            Console.WriteLine("Hello World!");
        }
    }
}
