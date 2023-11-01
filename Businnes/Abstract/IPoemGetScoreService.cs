using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businnes.Abstract
{
    public interface IPoemGetScoreService
    {
        IResult Add(PoemGetScore poemGetScore);
        IResult Delete(PoemGetScore poemGetScore);
        IResult Update(PoemGetScore poemGetScore);
        IDataResult<List<PoemGetScore>> GetAll();
    }
}
