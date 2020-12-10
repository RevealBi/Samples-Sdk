using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Reveal.Sdk;
using Reveal.Web.NetCore3._1.Reveal;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Reveal.Web.NetCore3._1
{
    public class Startup
    {
        private string _webRootPath;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _webRootPath = env.WebRootPath;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews().AddNewtonsoftJson();

            var embedSettings = new RevealEmbedSettings();
            embedSettings.LocalFileStoragePath = GetLocalFileStoragePath(_webRootPath);

            //You could configure the default disk locations used by RevealView to store cached data by uncommenting the following lines:
            var cacheFilePath = Configuration.GetSection("Caching")?["CacheFilePath"] ?? @"C:\Temp\Reveal\Web\Cache";
            Directory.CreateDirectory(cacheFilePath);
            embedSettings.DataCachePath = cacheFilePath;
            embedSettings.CachePath = cacheFilePath;

            services.AddRevealServices(embedSettings, new RevealContext());

            services.AddMvc().AddReveal().AddNewtonsoftJson();
        }

        protected virtual string GetLocalFileStoragePath(string webRootPath)
        {
            return Path.Combine(webRootPath, "LocalDatasourceFiles");
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
