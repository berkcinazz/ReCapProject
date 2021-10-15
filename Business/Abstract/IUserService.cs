using Core.DataAccess;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Delete(int userId);
        IDataResult<List<User>> GetUserAll();
        IDataResult<User> GetUserById(int userId);
        IDataResult<List<OperationClaim>> GetClaims(User user);
        //IDataResult<User> GetByMail(string mail);
        User GetByMail(string email);


    }
}
