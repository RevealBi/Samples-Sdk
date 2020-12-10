using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reveal.Sdk;

namespace Reveal.Web.NetCore3._1.Reveal
{
    public class RevealContext : RevealSdkContextBase
    {
        public override Task<Dashboard> GetDashboardAsync(string dashboardId)
        {
            throw new NotImplementedException();
        }

        public override Task SaveDashboardAsync(string userId, string dashboardId, Dashboard dashboard)
        {
            throw new NotImplementedException();
        }
    }
}
