using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IAnnalService
    {
        List<Annal> GetAll();
        Annal Get(int id);
        void Add(Annal annal);
        void Update(Annal annal);
        void Delete(Annal annal);
        void AddRange();
    }
}
