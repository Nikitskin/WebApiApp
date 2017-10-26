using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLogger;
using NLogger.Filters;
using WebAPITestApp.App_Start;

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
            });
            services.AddAutoMapper();
            services.AddSingleton<ILoggerService, LoggerService>();
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
