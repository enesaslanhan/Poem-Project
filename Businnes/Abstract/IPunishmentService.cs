using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businnes.Abstract
{
    public interface IPunishmentService
    {
        IResult Add(Punishment punishment);
        IResult Delete(int UserId);
        IResult Update(Punishment punishment);
        IDataResult<List<Punishment>> GetAll();
        IDataResult<Punishment> GetById(int UserId);
    }
}
