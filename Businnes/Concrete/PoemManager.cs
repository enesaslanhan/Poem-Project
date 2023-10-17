using Businnes.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businnes.Concrete
{
    public class PoemManager : IPoemService
    {
        IPoemDal _poemDal;
        public PoemManager(IPoemDal poemDal)
        {
            _poemDal = poemDal;
        }
        public IResult Add(Poem poem)
        {
            _poemDal.Add(poem);
            var result = _poemDal.Get(p => p.Id == poem.Id);
            if (result!=null)
            {
                return new SuccessResult("Şiir Eklendi");
            }
            return new ErrorResult("Şiir Eklenemedi");
        }

        public IResult Delete(int poemId)
        {
            var remove = _poemDal.Get(p => p.Id == poemId);
            _poemDal.Delete(remove);
            var result = _poemDal.Get(p => p.Id ==poemId);
            if (result ==null)
            {
                return new SuccessResult("Şiir silindi");
            }
            return new ErrorResult("Şiir silinemedi");
        }

        public IDataResult<List<Poem>> GetAll()
        {
            return new SuccessDataResult<List<Poem>>(_poemDal.GetAll());
        }

        public IDataResult<List<Poem>> GetByUserId(int userId)
        {
            return new SuccessDataResult<List<Poem>>(_poemDal.GetAll(p => p.UserId == userId));
        }

        public IResult Update(Poem poem)
        {
            var result = _poemDal.Get(p => p.Id == poem.Id);
            result.PoemName = poem.PoemName;
            result.PoemText = poem.PoemText;
            _poemDal.Update(result);
            return new SuccessResult("Şiir Güncellendi");
        }
    }
}
