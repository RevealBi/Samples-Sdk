using Reveal.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reveal.Web.NetCore3._1.Reveal
{

    public class ChangeDataSourceProvider : IRVDataSourceProvider
    {
        public Task<RVDataSourceItem> ChangeDashboardFilterDataSourceItemAsync(string userId, string dashboardId, RVDashboardFilter filter, RVDataSourceItem dataSourceItem)
        {
            return Task.FromResult(dataSourceItem);
        }

        public Task<RVDataSourceItem> ChangeVisualizationDataSourceItemAsync(string userId, string dashboardId, RVVisualization visualization, RVDataSourceItem dataSourceItem)
        {
            var azureDSI = dataSourceItem as RVAzureSqlDataSourceItem;

            //azureDSI.ProcedureParameters["@p1"] = 1;

            return Task.FromResult(dataSourceItem);
        }
    }
}
