using Businnes.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businnes.Concrete
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
            var result = UserControl(user.Email);
            if (result.Success==true)
            {
                _userDal.Add(user);
                return new SuccessResult("Kullanıcı Eklendi");
                
            }
            return new ErrorResult("Kullanıcı mevcut");
            
        }

        public IResult Delete(int UserId)
        {
            var remove = _userDal.Get(u => u.Id == UserId);
            _userDal.Delete(remove);
            var result = _userDal.Get(u => u.Id == UserId);
            if (result == null)
            {
                return new SuccessResult("Kullanıcı Silindi");
            }
            return new ErrorResult("Kullanıcı Silinemedi");
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll());
        }

        public IDataResult<User> GetByEmail(string email)
        {
            return new SuccessDataResult<User>(_userDal.Get(u => u.Email == email));
        }

        public IResult Update(User user)
        {
            var result = _userDal.Get(u => u.Id == user.Id);
            result.Email = user.Email;
            result.FakeName = user.FakeName;
            result.Password = user.Password;
            _userDal.Update(result);
            return new SuccessResult("Kullanıcı güncellendi");
        }
        private IResult UserControl(string email)
        {
            var result = GetByEmail(email);
            if (result.Data!=null)
            {
                return new ErrorResult();
            }
            return new SuccessResult();
        }
    }
}
