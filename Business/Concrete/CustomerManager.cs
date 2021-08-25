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
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult AddCustomer(Customer customer)
        {
            _customerDal.Add(customer);
            return new SuccessResult("Müşteri eklendi");
        }

        public IDataResult<List<Customer>> GetAllCustomer()
        {
            return new SuccessDataResult<List<Customer>>(_customerDal.GetAll());
        }

        public IDataResult<Customer> GetCustomerById(int customerId)
        {
            return new SuccessDataResult<Customer>(_customerDal.Get(c=>c.Id==customerId));
        }
    }
}
