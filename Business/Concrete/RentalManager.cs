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
        public IResult AddRental(Rental rental)
        {
            if (rental.ReturnDate == null)
            {
                return new ErrorResult("Selected car is not available. Because using already.");
            }
            else
            {
                _rentaldal.Add(rental);
                return new SuccessResult("Well done. Your rent process working well.");
            }
        }

        
        public IDataResult<List<Rental>> GetAllRental()
        {
            
            return new SuccessDataResult<List<Rental>>(_rentaldal.GetAll(),"Başarıyla listelendi");
        }
        public IDataResult<Rental> GetRentalById(int rentalId)
        {
            
            return new SuccessDataResult<Rental>(_rentaldal.Get(r=>r.Id==rentalId),"Seçtiğiniz kiralama listelenmiştir");
        }
    }
}
