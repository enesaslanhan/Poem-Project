using Businnes.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businnes.Concrete
{
    public class PoemGetScoreManager : IPoemGetScoreService
    {
        IPoemGetScoreDal _poemGetScoreDal;
        public PoemGetScoreManager(IPoemGetScoreDal poemGetScoreDal)
        {
            _poemGetScoreDal = poemGetScoreDal;
        }
        public IResult Add(PoemGetScore poemGetScore)
        {
            var result = CheckIfPoemGetScore(poemGetScore);
            if (result.Success)
            {
                _poemGetScoreDal.Add(poemGetScore);
                return new SuccessResult();
            }
            else
            {
                var result2 = Update(poemGetScore);
                if (result2.Success)
                {
                    return new SuccessResult();
                }
                return new ErrorResult();
                
            }
            
        }

        public IResult Delete(int poemId)
        {
            var remove = _poemGetScoreDal.Get(pgs => pgs.PoemId == poemId);
            if (remove!=null)
            {
                _poemGetScoreDal.Delete(remove);
            }
            var result = _poemGetScoreDal.Get(pgs => pgs.PoemId == poemId);
            if (result==null)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
            
        }

        public IDataResult<List<PoemGetScore>> GetAll()
        {
            return new SuccessDataResult<List<PoemGetScore>>(_poemGetScoreDal.GetAll());
        }

        public IResult Update(PoemGetScore poemGetScore)
        {
            var result = _poemGetScoreDal.Get(p => p.PoemId == poemGetScore.PoemId);
            if (result!=null)
            {

                result.Score = ((result.Score*result.NumberOfUser)+poemGetScore.Score)/(result.NumberOfUser+1);
                result.NumberOfUser=result.NumberOfUser+1;
                _poemGetScoreDal.Update(result);
                return new SuccessResult();
            }
            return new ErrorResult();
        }
        private IResult CheckIfPoemGetScore(PoemGetScore poemGetScore)
        {
            var result = _poemGetScoreDal.Get(pg => pg.PoemId == poemGetScore.PoemId);
            if (result==null)
            {
                return new  SuccessResult();
            }
            return new ErrorResult();
        }
    }
}
