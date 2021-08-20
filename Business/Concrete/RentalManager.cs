using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentaldal;

        public RentalManager(IRentalDal rentaldal)
        {
            _rentaldal = rentaldal;
        }

        public void Add(Rental entity)
        {
            if (entity.ReturnDate==null)
            {
                Console.WriteLine(new ErrorResult("Selected car is not available. Because using already."));
            }
            else
            {
                Console.WriteLine(new SuccessResult("Well done. Your rent process working well."));
                _rentaldal.Add(entity);
            }
        }

        public void Delete(Rental entity)
        {
            throw new NotImplementedException();
        }

        public Rental Get(Expression<Func<Rental, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Rental> GetAll(Expression<Func<Rental, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Rental GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Rental entity)
        {
            throw new NotImplementedException();
        }
    }
}
