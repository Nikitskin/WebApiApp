using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DBLayer.DBRepository;
using DBLayer.DbData;
using System.Data.Entity;
using DBLayer.Contexts;
using DBLayer.UnitOfWork;

namespace WebAPITestApp
{
    public partial class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddScoped<DbContext, OrderContext>();
            services.AddScoped<IDBRepository<Order>, DBRepository<Order>>();
            services.AddScoped<IDBRepository<Product>, DBRepository<Product>>();
            services.AddScoped<IDBRepository<User>, DBRepository<User>>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseMvc();
        }
    }
}
