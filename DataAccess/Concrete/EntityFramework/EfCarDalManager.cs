using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDalManager : ICarDal
    {
        public void Add(Car entity)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                if (entity.Description.Length >=2 )
                {
                    if (entity.DailyPrice > 0)
                    {
                        var addingCar = context.Entry(entity);
                        addingCar.State = EntityState.Added;
                        context.SaveChanges();
                        Console.WriteLine("Tebrikler, arabanız eklendi");
                    }
                    else
                    {
                        Console.WriteLine("Günlük fiyatı 0 dan büyük olmalı");
                    }
                }
                else
                {
                    Console.WriteLine("Araba isminiz 2 haneden büyük olmalı.");
                }
                
            }
        }

        public void Delete(Car entity)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var deletingCar = context.Entry(entity);
                deletingCar.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                return context.Set<Car>().SingleOrDefault(filter);
            }
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                return filter == null
                    ? context.Set<Car>().ToList()
                    : context.Set<Car>().Where(filter).ToList();
            } 
        }

        public void Update(Car entity)
        {
            using (ReCapProjectContext context = new ReCapProjectContext())
            {
                var updatingCar = context.Entry(entity);
                updatingCar.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
