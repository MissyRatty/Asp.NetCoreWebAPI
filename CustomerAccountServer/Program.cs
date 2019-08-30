using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Serilog;

namespace CustomerAccountServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>

            //CreateDefaultBuilder encapsulates the old UseKestrel() and UseIISIntegration().
            WebHost.CreateDefaultBuilder(args)

                // Startup class is mandatory for .netcore, its used to configure embedded or custom services that our application needs.
                .UseStartup<Startup>()

            // Hook Serilog into the Web API
            .UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
            .ReadFrom.Configuration(hostingContext.Configuration));
    }
}
