using DataAccess.Tenant.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Tenant.Concrete
{
    public class TenantResolver : ITenantResolver
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ITenantCatalog _tenantCatalog;

        public TenantResolver(IHttpContextAccessor httpContextAccessor, ITenantCatalog tenantCatalog)
        {
            _httpContextAccessor = httpContextAccessor;
            _tenantCatalog = tenantCatalog;
        }

        public async Task<AppTenant> Resolve()
        {
            var hostname = _httpContextAccessor.HttpContext.Request.Host.Value;
            var tenant = await _tenantCatalog.Get(t => t.HostName == hostname);
            return tenant;
        }
    }
}
