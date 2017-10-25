using AutoMapper;
using Logger;
using Logger.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using WebAPITestApp.App_Start;

namespace WebAPITestApp
{
    public class Startup
    {
        private IConfiguration Configuration { get; }
        private ILoggerService Logger { get; }

        public Startup(IConfiguration configuration, ILoggerService logger)
        {
            Configuration = configuration;
            Logger = logger;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            try
            {
                Logger.Info("Starting services..");
                services.RegisterAuthorization();
                services.RegisterDatabase(Configuration.GetSection("ShopConnection:ConnectionString").Value);
                services.AddMvc(options =>
                {
                    options.Filters.Add(typeof(GlobalNLogExceptionFilter));
                    options.Filters.Add(typeof(ActionMethodNLogFilter));
                });
                services.AddAutoMapper();
                services.AddSingleton<ILoggerService, LoggerService>();
                Logger.Info("Services initialized.");
            }
            catch (Exception e)
            {
                Logger.Error("Services initializing failed, because of {0}", e.ToString());
            }
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            app.UseDefaultFiles();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
