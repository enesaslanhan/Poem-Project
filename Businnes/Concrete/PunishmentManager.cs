using Businnes.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businnes.Concrete
{
    public class PunishmentManager : IPunishmentService
    {
        IPunishmentDal _punishmentDal;
        public PunishmentManager(IPunishmentDal punishmentDal)
        {
            _punishmentDal = punishmentDal;
        }
        public IResult Add(Punishment punishment)
        {
            var result = _punishmentDal.Get(p => p.UserId == punishment.UserId);
            if (result==null)
            {
                _punishmentDal.Add(punishment);
                return new SuccessResult();
            }
            var result2 = Update(punishment);
            if (result2.Success)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IResult Delete(int UserId)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Punishment>> GetAll()
        {
            return new SuccessDataResult<List<Punishment>>(_punishmentDal.GetAll());
        }

        public IDataResult<Punishment> GetById(int UserId)
        {
            return new SuccessDataResult<Punishment>(_punishmentDal.Get(p => p.UserId==UserId));

        }

        public IResult Update(Punishment punishment)
        {
            var result = _punishmentDal.Get(p=>p.UserId==punishment.UserId);
            if (result!=null)
            {
                result.PunishmentEndDay = punishment.PunishmentEndDay;
                result.PunishmentStartingDay = punishment.PunishmentStartingDay;
                _punishmentDal.Update(result);
                return new SuccessResult();
            }
            return new ErrorResult();
            
        }
    }
}
