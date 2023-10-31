using Businnes.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businnes.Concrete
{
    public class PoemScoreManager : IPoemScoreService
    {
        IPoemScoreDal _poemScoreDal;
        public PoemScoreManager(IPoemScoreDal poemScoreDal)
        {
            _poemScoreDal = poemScoreDal;
        }
        
        public IResult Add(PoemScore poemScore)
        {
            var result2 = CheckIfScore(poemScore);
            if (result2.Success)
            {
                _poemScoreDal.Add(poemScore);
                var result = _poemScoreDal.Get(ps => ps.Id == poemScore.Id);
                if (result != null)
                {
                    return new SuccessResult("Puan verildi");
                }
                return new ErrorResult("Puan verilemedi");
            }
            return new ErrorResult("Bir şiire birden fazla puan veremezsiniz");
            
            
        }

        public IResult Delete(PoemScore poemScore)
        {
            var remove = _poemScoreDal.Get(ps=>ps.Id==poemScore.Id);
            _poemScoreDal.Delete(remove);
            var result = _poemScoreDal.Get(ps => ps.Id == poemScore.Id);
            if (result == null)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IDataResult<List<PoemScore>> GetAll()
        {
            return new SuccessDataResult<List<PoemScore>>(_poemScoreDal.GetAll());
        }

        public IDataResult<List<PoemScore>> GetByPoemId(int poemId)
        {
            return new SuccessDataResult<List<PoemScore>>(_poemScoreDal.GetAll(ps => ps.PoemId == poemId));
        }

        public IDataResult<List<PoemScore>> GetByUserId(int userId)
        {
            return new SuccessDataResult<List<PoemScore>>(_poemScoreDal.GetAll(ps => ps.UserId == userId));
        }

        public IResult Update(PoemScore poemScore)
        {
            var result = _poemScoreDal.Get(ps => ps.Id == poemScore.Id);
            result.Score = poemScore.Score;
            _poemScoreDal.Update(result);
            return new SuccessResult("Puan Güncellendi");
        }
        private IResult CheckIfScore(PoemScore poemScore)
        {
            var result = _poemScoreDal.GetAll(p => p.UserId == poemScore.UserId);
            foreach (var item in result)
            {
                if (item.PoemId==poemScore.PoemId)
                {
                    return new ErrorResult();
                }
            }
            return new SuccessResult();
            
        }
    }
}
