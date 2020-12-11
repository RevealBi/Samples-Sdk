using Reveal.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reveal.Web.NetCore3._1.Reveal
{
    public class AuthenticationProvider : IRVAuthenticationProvider
    {
        public Task<IRVDataSourceCredential> ResolveCredentialsAsync(string userId, RVDashboardDataSource dataSource)
        {
            // Reveal Sdk is calling this method when it needs credentials to connect to a specific datasource used in dashboard
            // Here you could inspect the actual datasource Reveal need to connect to and provide the appropriate credentials

            IRVDataSourceCredential datasouceCredential;
            var sqlServerDs = dataSource as RVSqlServerDataSource;
            if (sqlServerDs != null && sqlServerDs.Host == "specific host")
            {
                datasouceCredential = new RVUsernamePasswordDataSourceCredential("<username>", "<password>", "<domain>");
            }
            else
            {
                datasouceCredential = null;
            }

            return Task.FromResult(datasouceCredential);
        }
    }
}
