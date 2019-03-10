using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Identity.API
    {
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config)=>{
                    config.SetBasePath(Directory.GetCurrentDirectory());
                    config.AddJsonFile("Configurations/mongoSettings.json", optional:false, reloadOnChange:true);
                    //config.AddInMemoryCollection();
                    config.AddCommandLine(args);
                })
                .UseStartup<Startup>()
                .ConfigureKestrel((context, options)=>{
                    options.Listen(IPAddress.Loopback, 3000);
                });
    }
}
