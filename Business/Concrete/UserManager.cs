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

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessDataResult<User>("Başarıyla silindi");
        }

        public IDataResult<List<User>> GetUserAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(),"Kullanıcılar başarıyla listelendi");
        }

        public IDataResult<User> GetUserById(int userId)
        {
            return new SuccessDataResult<User>(_userDal.Get(u=>u.Id==userId),"Seçtiğiniz idye göre listelendi");
        }
    }
}
