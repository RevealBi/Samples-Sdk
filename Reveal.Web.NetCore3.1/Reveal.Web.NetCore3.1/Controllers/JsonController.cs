using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reveal.Sdk.Samples.Web.UpMedia.Controllers
{
    public class JsonController : Controller
    {
        public class Entity
        {
            public int Id { get; set; }
            public string FullName { get; set; }
        }
        List<Entity> _data = new List<Entity>()
        {
            new Entity(){ Id = 0, FullName = "Jack" },
            new Entity(){ Id = 1, FullName = "Sam" }
        };

        public List<Entity> GetData()
        {
            return new List<Entity>()
                    {
                        new Entity(){ Id = 0, FullName = "Jack" },
                        new Entity(){ Id = 1, FullName = "Sam" }
                    };
        }
    }
}
