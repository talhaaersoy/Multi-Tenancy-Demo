using DataAccess.Abstract;
using DataAccess.RepositoryBase;
using DataAccess.Tenant.Abstract;
using DataAccess.Tenant.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete
{
    public class EfAnnalDal: IAnnalDal
    {
        private readonly ITenantResolver _tenantResolver;

        public EfAnnalDal(ITenantResolver tenantResolver)
        {
            _tenantResolver = tenantResolver;
        }

        public List<Annal> GetAll(Expression<Func<Annal, bool>> filter = null)
        {
            using (AnnalContext context = new AnnalContext(_tenantResolver))
            {
                return filter == null
                    ? context.Set<Annal>().ToList()
                    : context.Set<Annal>().Where(filter).ToList();
            }
        }

        public Annal Get(Expression<Func<Annal, bool>> filter)
        {
            using (AnnalContext context = new AnnalContext(_tenantResolver))
            {
                return context.Set<Annal>().SingleOrDefault(filter);
            }
        }

        public void Add(Annal entity)
        {
            using (AnnalContext context = new AnnalContext(_tenantResolver))
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Update(Annal entity)
        {
            using (AnnalContext context = new AnnalContext(_tenantResolver))
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(Annal entity)
        {
            using (AnnalContext context = new AnnalContext(_tenantResolver))
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
       
        
    }
}
