using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NLog.Extensions.Logging;
using NLog.Web;
using WebAPITestApp.DBLayer.Contexts;
using WebAPITestApp.DBLayer.DbData;
using WebAPITestApp.NLogger;
using WebAPITestApp.Web.Infrastructure.Attributes;
using WebAPITestApp.Web.Infrastructure.Filters;
using WebAPITestApp.Web.Infrastructure.Middleware;

namespace WebAPITestApp.Web
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
            services.AddIdentity<User, IdentityRole>().
                AddEntityFrameworkStores<OrderContext>().
                AddDefaultTokenProviders();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller?}/{action?}", new { controller = "home", action = "index" });
            });

            loggerFactory.AddNLog();
            app.AddNLogWeb();
            env.ConfigureNLog("../NLogger/nlog.config");
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseAuthentication();
        }
    }
}
