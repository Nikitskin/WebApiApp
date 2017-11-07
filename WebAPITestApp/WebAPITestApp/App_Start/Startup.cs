using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NLog.Extensions.Logging;
using NLog.Web;
using NLogger;
using WebAPITestApp.Infrastructure.Attributes;
using WebAPITestApp.Infrastructure.Filters;

namespace WebAPITestApp
{
    public class Startup
    {
        private IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.RegisterAuthorization();
            services.RegisterDatabase(Configuration.GetSection("ShopConnection:ConnectionString").Value);
            services.AddMvc(options =>
            {
                options.Filters.Add(typeof(GlobalNLogExceptionFilter));
                options.Filters.Add(typeof(ActionMethodNLogFilter));
                options.Filters.Add(typeof(ValidateModelAttribute));
            }).AddJsonOptions(options =>
            {
                options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            services.AddAutoMapper();
            services.AddSingleton<ILoggerService, LoggerService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddNLog();
            app.AddNLogWeb();
            env.ConfigureNLog("../NLogger/nlog.config");
            app.UseStaticFiles();
            app.UseDefaultFiles();
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
