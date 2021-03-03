using Core.Entities.Concrete;
using DataAccess.Tenant.Abstract;
using DataAccess.Tenant.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete
{
    public class AnnalContext : DbContext
    {
        public virtual DbSet<Annal> Annals { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<OperationClaim> OperationClaims { get; set; }
        public virtual DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        private readonly AppTenant _tenant;

        public AnnalContext(ITenantResolver tenantResolver)
        {
            _tenant = tenantResolver.Resolve().GetAwaiter().GetResult();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = _tenant.ConnectionString;
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
