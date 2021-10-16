using Core.DataAccess;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IResult AddRental(RentalForAddDto rental);
        IDataResult<List<Rental>> GetAllRental();
        IDataResult<Rental> GetRentalById(int rentalId);
        IDataResult<List<RentalForListingDto>> GetAllRentalsDetail();
    }
}
