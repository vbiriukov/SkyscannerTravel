using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SkyscannerTravel.Helpers;
using SkyscannerTravel.Models.Responses.Continents;
using SkyscannerTravel.Providers.Interfaces;

namespace SkyscannerTravel
{
    //public class Program
    //{
    //    public static async Task Main(string[] args)
    //    {
    //        IWebHost host = CreateWebHostBuilder(args).Build();

    //        using (var scope = host.Services.CreateScope())
    //        {
    //            //ISkyscannerProvider userManager = scope.ServiceProvider.GetRequiredService<ISkyscannerProvider>();

    //            var path = Path.Combine("Files", "get_list_of_continents.json");

    //            ListOfContinents listOfContinents = await FileHelper.GetData<ListOfContinents>(path);

    //            path = Path.Combine("Files", "get_list_of_continents.json");

    //            await FileHelper.SaveData(path, listOfContinents);
    //        }
    //    }

    //    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
    //        WebHost.CreateDefaultBuilder(args)
    //            .UseStartup<Startup>();
    //}

    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
