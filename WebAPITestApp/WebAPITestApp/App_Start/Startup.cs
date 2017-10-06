using DBLayer.Contexts;
using DBLayer.DbData;
using DBLayer.DBRepository;
using DBLayer.UnitOfWork;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Owin;

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
            services.AddDbContext<OrderContext>();
            services.AddScoped<IDBRepository<Order>, DBRepository<Order>>();
            services.AddScoped<IDBRepository<Product>, DBRepository<Product>>();
            services.AddScoped<IDBRepository<User>, DBRepository<User>>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public void Configure(IAppBuilder app, IHostingEnvironment env)
        {
            ConfigureAuth(app);
            //TODO remove this
            //app.UseMvc();
        }
    }
}
