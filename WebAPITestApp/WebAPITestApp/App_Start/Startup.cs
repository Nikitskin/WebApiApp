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
using Swashbuckle.AspNetCore.Swagger;
using WebAPITestApp.NLogger;
using WebAPITestApp.Web.Infrastructure.Attributes;
using WebAPITestApp.Web.Infrastructure.Filters;
using WebAPITestApp.Web.Infrastructure.MappingProfilers;
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
            services.AddTransient<IMap, Infrastructure.MappingProfilers.Mapper>();
            services.AddAutoMapper();
            services.AddSingleton<ILoggerService, LoggerService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Web api test solution API", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            
            loggerFactory.AddNLog();
            app.AddNLogWeb();
            env.ConfigureNLog("../NLogger/nlog.config");
            app.UseStaticFiles();
            app.UseDefaultFiles();
            app.UseMiddleware<ErrorHandlerMiddleware>();
            app.UseAuthentication();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
