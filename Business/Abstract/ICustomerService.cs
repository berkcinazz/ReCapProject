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
    public interface ICustomerService
    {
        IResult AddCustomer(CustomerForAddDto customer);
        IDataResult<List<Customer>> GetAllCustomer();
        IDataResult<Customer> GetCustomerById(int customerId);

    }
}
