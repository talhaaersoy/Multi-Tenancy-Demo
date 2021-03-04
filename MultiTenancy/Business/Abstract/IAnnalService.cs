using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAnnalService
    {
        IDataResult<List<Annal>> GetAll();
        IDataResult<Annal> Get(int id);
        IResult Add(Annal annal);
        IResult Update(Annal annal);
        IResult Delete(Annal annal);

    }
}
