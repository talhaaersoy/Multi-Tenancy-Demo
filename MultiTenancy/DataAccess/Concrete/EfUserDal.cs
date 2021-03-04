using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System.Linq;
using System.Linq.Expressions;
using DataAccess.Tenant.Abstract;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : IUserDal
    {

        private readonly ITenantResolver _tenantResolver;

        public EfUserDal(ITenantResolver tenantResolver)
        {
            _tenantResolver = tenantResolver;
        }

        public List<User> GetAll(Expression<Func<User, bool>> filter = null)
        {
            using (AnnalContext context = new AnnalContext(_tenantResolver))
            {
                return filter == null
                    ? context.Set<User>().ToList()
                    : context.Set<User>().Where(filter).ToList();
            }
        }

        public User Get(Expression<Func<User, bool>> filter)
        {
            using (AnnalContext context = new AnnalContext(_tenantResolver))
            {
                return context.Set<User>().SingleOrDefault(filter);
            }
        }

        public void Add(User entity)
        {
            using (AnnalContext context = new AnnalContext(_tenantResolver))
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Update(User entity)
        {
            using (AnnalContext context = new AnnalContext(_tenantResolver))
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(User entity)
        {
            using (AnnalContext context = new AnnalContext(_tenantResolver))
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new AnnalContext(_tenantResolver))
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.Id
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }

    }
}
