using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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
        public IResult AddRental(RentalForAddDto rental)
        {
            Rental addToRental = new Rental()
            {
                CarId=rental.CarId,
                CustomerId = rental.CustomerId,
                RentDate = rental.RentDate,
                ReturnDate = rental.ReturnDate

            };
            if (rental.ReturnDate == null)
            {
                return new ErrorResult(Messages.CarIsNotAvailable);
            }
            else
            {
                _rentaldal.Add(addToRental);
                return new SuccessResult(Messages.RentalAdded);
            }
        }

        
        public IDataResult<List<Rental>> GetAllRental()
        {
            var result = _rentaldal.GetAll();
            return new SuccessDataResult<List<Rental>>(result);
        }

        public IDataResult<List<RentalForListingDto>> GetAllRentalsDetail()
        {
            var result = _rentaldal.GetAllRentalDetails();
            return new SuccessDataResult<List<RentalForListingDto>>(result);
        }

        public IDataResult<Rental> GetRentalById(int rentalId)
        {
            var result = _rentaldal.Get(r => r.Id == rentalId);
            return new SuccessDataResult<Rental>(result);
        }
    }
}
