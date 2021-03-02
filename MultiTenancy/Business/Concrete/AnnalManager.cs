using AutoMapper;
using Business.Abstract;
using Business.Mapping;
using DataAccess.Abstract;
using Entities.Concrete;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business.Concrete
{
    public class AnnalManager : IAnnalService
    {
        private readonly IAnnalDal _annalDal;

        public AnnalManager(IAnnalDal annalDal)
        {
            _annalDal = annalDal;
        }

        public void Add(Annal annal)
        {
            _annalDal.Add(annal);
        }

        public void Delete(Annal annal)
        {
            _annalDal.Delete(annal);
        }

        public Annal Get(int id)
        {
            return _annalDal.Get(b => b.Id == id);
        }

        public List<Annal> GetAll()
        {
            return _annalDal.GetAll();
        }

        public void Update(Annal annal)
        {
            _annalDal.Update(annal);
        }
        
    }
}
