using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult("User başarıyla eklendi");
        }

        public IResult Delete(int userId)
        {
            var user = _userDal.Get(u=>u.Id==userId);
            if (user == null) return new ErrorResult(Messages.UserNotFound);
            _userDal.Delete(user);
            return new SuccessDataResult<User>("Başarıyla silindi");
        }

        public User GetByMail(string email)
        {
            //var result = _userDal.Get(u => u.Email == email);
            //if (result == null) return new ErrorDataResult<User>(Messages.UserNotFoundWithThisMail);
            //return new SuccessDataResult<User>(result);
            return _userDal.Get(u => u.Email == email);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var result = _userDal.GetOperationClaims(user.Id);
            return new SuccessDataResult<List<OperationClaim>>(result);
        }

        public IDataResult<List<User>> GetUserAll()
        {
            var result = _userDal.GetAll();
            return new SuccessDataResult<List<User>>(result);
        }

        public IDataResult<User> GetUserById(int userId)
        {
            var result = _userDal.Get(u => u.Id == userId);
            return new SuccessDataResult<User>(result);
        }

       
    }
}
