using CustomerAccountServer.BLL.Classes;
using CustomerAccountServer.BLL.Interfaces;
using CustomerAccountServer.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CustomerAccountServer.Helpers.Extensions
{
    public static class ServiceExtension
    {
        // configure CORS in the application. CORS (Cross-Origin Resource Sharing) is a mechanism that gives rights to a client app or user to access
        // resources of this API from a different domain.
        // since this API will be called by a VueJs client app which will be running on a different domain from what this API will be running on, configuring CORS is mandatory.
        public static void ConfigureCors(this IServiceCollection services)
        {
            //Note: Instead of AllowAnyOrigin which allows requests from any source, could use WithOrigins("aSpecificURL"),
            //this will allow requests just from the specified source.

            // Note: Instead of AllowAnyMethod, which allows all HTTP methods, could use WithMethods("POST", "GET")
            // this will restrict to only the specified HTTP methods/ verbs.

            // Note: Instead of AllowAnyHeader(), could have used WithHeaders("accept", "content-type") method to allow only specified headers.


            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials());
            });
        }

        // Configure IIS to help with IIS Deployment later.
        public static void ConfigureIISIntegration(this IServiceCollection services)
        {
            services.Configure<IISOptions>(options => {
                // no initialization of properties as the default are just fine for now.
                options.AutomaticAuthentication = true;
                options.AuthenticationDisplayName = "RahmatTesting";
                options.ForwardClientCertificate = true;
            });

        }

        // Configure SQL Server Connection
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration config) {
            var connectionString = config["sqlServerConnection:connectionString"];
            services.AddDbContext<RepositoryContext>(options => options.UseSqlServer(connectionString));
        }

        // Configure Unit Of Work Interface and Implementation
        public static void ConfigureRepositoryUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryUnitOfWork, RepositoryUnitOfWork>();
        }
    }
}
