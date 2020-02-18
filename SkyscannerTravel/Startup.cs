using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SkyscannerTravel.Filters;
using SkyscannerTravel.Mappers;
using SkyscannerTravel.Mappers.Interfaces;
using SkyscannerTravel.Providers;
using SkyscannerTravel.Providers.Interfaces;
using SkyscannerTravel.Services;
using SkyscannerTravel.Services.MoсkedServices;
using SkyscannerTravel.Services.Interfaces;

namespace SkyscannerTravel
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            InjectServices(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }


        private void InjectServices(IServiceCollection services)
        {
            services.AddScoped<ErrorFilter>();
            services.AddTransient<ISkyscannerProvider, SkyScannerProvider>();

            services.AddTransient<ISkyscannerService, SkyscannerService>();
            services.AddTransient<ISkyscannerMapper, SkyscannerMapper>();

            bool isMocked = Configuration.GetValue<bool>("IsMocked");

            if (isMocked)
            {
                services.AddTransient<ILocationService, MockedLocationService>();
                services.AddTransient<IFlightService, MockedFlightService>();
            }
            if (!isMocked)
            {
                services.AddTransient<ILocationService, LocationService>();
                services.AddTransient<IFlightService, FlightService>();
            }
        }
    }
}
