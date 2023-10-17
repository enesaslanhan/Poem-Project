using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businnes.Abstract
{
    public interface IPoemScoreService
    {
        IResult Add(PoemScore poemScore);
        IResult Delete(PoemScore poemScore);
        IResult Update(PoemScore poemScore);
        IDataResult<List<PoemScore>> GetAll();
        IDataResult<List<PoemScore>> GetByPoemId(int poemId);
        IDataResult<List<PoemScore>> GetByUserId(int userId);

    }
}
