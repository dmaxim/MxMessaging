using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Mx.Messaging.Api
{
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

                })
                .UseSerilog((context, configuration) => { configuration.ReadFrom.Configuration(context.Configuration); });

        //public static IWebHost BuildWebHost(string[] args) =>
        //    WebHost.CreateDefaultBuilder(args)
        //        .ConfigureAppConfiguration(configurationBuilder =>
        //        {
        //            configurationBuilder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
        //        })
        //        .UseStartup<Startup>()
        //        .UseSerilog((context, configuration) => { configuration.ReadFrom.Configuration(context.Configuration); })
        //        .Build();
    }
}
