﻿using Businnes.Abstract;
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

        public IResult Delete(PoemGetScore poemGetScore)
        {
            _poemGetScoreDal.Delete(poemGetScore);
            return new SuccessResult();
        }

        public IDataResult<List<PoemGetScore>> GetAll()
        {
            return new SuccessDataResult<List<PoemGetScore>>(_poemGetScoreDal.GetAll());
        }

        public IResult Update(PoemGetScore poemGetScore)
        {
            var result = _poemGetScoreDal.Get(p => p.Id == poemGetScore.Id);
            if (result!=null)
            {

                result.Score = result.Score;
                result.NumberOfUser++;
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