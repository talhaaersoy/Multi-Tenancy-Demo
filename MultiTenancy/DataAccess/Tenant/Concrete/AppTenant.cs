using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Tenant.Concrete
{
    public class AppTenant
    {
        public string Name { get; set; }
        public string HostName { get; set; }
        public string ConnectionString { get; set; }
    }
}
