using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Reveal.Sdk;

namespace Reveal.Web.NetCore3._1.Reveal
{
    public class RevealContext : RevealSdkContextBase
    {
        IRVAuthenticationProvider _authProvider = new AuthenticationProvider();
        IRVDataSourceProvider _changeDataSourceProvider = new ChangeDataSourceProvider();

        public override Task<Dashboard> GetDashboardAsync(string dashboardId)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var allResourcesNames = assembly.GetManifestResourceNames();

            var targetResourceName = allResourcesNames.FirstOrDefault(name => name.Contains(dashboardId));
            if (targetResourceName != null)
            {
                var dashboardStream = assembly.GetManifestResourceStream(targetResourceName);
                return Task.FromResult(new Dashboard(dashboardStream));
            }
            else
            {
                throw new ArgumentException($"No {dashboardId} found!");
            }
        }

        public override Task SaveDashboardAsync(string userId, string dashboardId, Dashboard dashboard)
        {
            throw new NotImplementedException();
        }

        public override IRVAuthenticationProvider AuthenticationProvider => _authProvider;


        public override IRVDataSourceProvider DataSourceProvider => _changeDataSourceProvider;

    }
}
