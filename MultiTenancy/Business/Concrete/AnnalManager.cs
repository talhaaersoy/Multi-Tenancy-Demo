
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize()]
        [ValidationAspect(typeof(AnnalValidator))]
        public IResult Add(Annal annal)
        {
            _annalDal.Add(annal);
            return new SuccessResult();
        }
        [Authorize()]
        public IResult Delete(Annal annal)
        {
            _annalDal.Delete(annal);
            return new SuccessResult();
        }
        
        public IDataResult<Annal> Get(int id)
        {
            
            return new SuccessDataResult<Annal>(_annalDal.Get(b => b.Id == id));
        }

        public IDataResult<List<Annal>> GetAll()
        {
           
            return new SuccessDataResult<List<Annal>>(_annalDal.GetAll());
        }
        [Authorize()]
        [ValidationAspect(typeof(AnnalValidator))]
        public IResult Update(Annal annal)
        {
            _annalDal.Update(annal);
            return new SuccessResult();
        }
        
    }
}
