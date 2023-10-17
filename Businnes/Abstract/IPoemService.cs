using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businnes.Abstract
{
    public interface IPoemService
    {
        IResult Add(Poem poem);
        IResult Delete(int poemId);
        IResult Update(Poem poem);
        IDataResult<List<Poem>> GetAll();
        IDataResult<List<Poem>> GetByUserId(int userId);

    }
}
