using DataAccess.Tenant.Abstract;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Tenant.Concrete
{
    public class TenantCatalog : ITenantCatalog
    {
        private readonly IEnumerable<AppTenant> db;

        public TenantCatalog(IConfiguration configuration)
        {
            db = configuration.GetTenantConfig();
        }

        public Task<AppTenant> Get(Func<AppTenant, bool> filterExp)
        {
            return Task.FromResult(db.Where(filterExp).FirstOrDefault());
        }
    }
}
