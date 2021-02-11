using Microsoft.AspNetCore.Http;
using Reveal.Sdk;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Reveal.Web.NetCore3._1.Reveal
{

    public class ChangeDataSourceProvider : IRVDataSourceProvider
    {

        public ChangeDataSourceProvider()
        {

        }


        public Task<RVDataSourceItem> ChangeDashboardFilterDataSourceItemAsync(string userId, string dashboardId, RVDashboardFilter filter, RVDataSourceItem dataSourceItem)
        {
            return Task.FromResult(dataSourceItem);
        }

        public Task<RVDataSourceItem> ChangeVisualizationDataSourceItemAsync(string userId, string dashboardId, RVVisualization visualization, RVDataSourceItem dataSourceItem)
        {
            if (visualization.Title == "CustomerLogo" && dataSourceItem is RVWebResourceDataSourceItem)
            {
                var logoFileNameToUse = GetCurrentCusomerLogoFileName();
                var localDsItem = new RVLocalFileDataSourceItem()
                {
                    Id = logoFileNameToUse,
                    Uri = $"local:/CustomerLogos/{logoFileNameToUse}"

                };

                return Task.FromResult((RVDataSourceItem)localDsItem);
            }

            return Task.FromResult(dataSourceItem);
        }

        private readonly Random _random = new Random();
        private readonly List<string> _availableLogos = new List<string>() 
        {
            "reveal.png",
            "infragistics.jpg",
            "igniteui.png"
        };
        private static int _counter = 0;
        private string GetCurrentCusomerLogoFileName()
        {
            var logo = _availableLogos[_counter % 3];
            _counter++;

            return logo;
        }
    }
}
