using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businnes.Abstract
{
    public interface IUserService
    {
        IResult Add(User user);
        IResult Delete(int UserId);
        IResult Update(User user);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetByEmail(string email);
        IDataResult<User> GetById(int id);
    }
}
