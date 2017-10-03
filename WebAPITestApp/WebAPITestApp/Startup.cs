using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DBLayer.DBRepository;
using DBLayer.DbData;
using WebAPITestApp.Services;
using System.Data.Entity;
using DBLayer.Contexts;

namespace WebAPITestApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddTransient<IDBRepository<Order>, DBRepository<Order>>();
            services.AddTransient<RepositoryService<Order>>();
            services.AddTransient<DbContext, OrderContext>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
            app.UseMiddleware<RepositoryMiddleware<Order>>();
        }
    }
}
