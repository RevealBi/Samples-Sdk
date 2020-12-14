using Reveal.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Reveal.Web.NetCore3._1.Reveal
{
    public class RevealUserContext : IRevealUserContext
    {
        public string GetUserId(ClaimsPrincipal principal)
        {
            // What you return here would be the value provide as the userId parameter of the ChangeVisualizationDataSourceItemAsync
            // method when you're overiding the stored procedures parameters.

            return principal.ToString(); 
        }
    }
}
