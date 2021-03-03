using DataAccess.Tenant.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Tenant.Abstract
{
    public interface ITenantCatalog
    {
        Task<AppTenant> Get(Func<AppTenant, bool> filterExp);
    }
}
