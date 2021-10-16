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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult AddCustomer(CustomerForAddDto customer)
        {
            Customer addToCustomer = new Customer (){ 
            CompanyName=customer.CompanyName,
            UserId=customer.UserId
            };
            _customerDal.Add(addToCustomer);
            return new SuccessResult(Messages.AddedCustomer);
        }

        public IDataResult<List<Customer>> GetAllCustomer()
        {
            var result = _customerDal.GetAll();
            return new SuccessDataResult<List<Customer>>(result);
        }

        public IDataResult<Customer> GetCustomerById(int customerId)
        {
            var result = _customerDal.Get(c => c.Id == customerId);
            return new SuccessDataResult<Customer>(result);
        }
    }
}
