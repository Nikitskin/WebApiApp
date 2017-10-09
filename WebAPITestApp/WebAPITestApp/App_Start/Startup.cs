using DBLayer.Contexts;
using DBLayer.DbData;
using DBLayer.DBRepository;
using DBLayer.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ServiceLayer.DatabaseServices;

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
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.Audience = AuthOptions.AUDIENCE;
                options.Authority = AuthOptions.AUDIENCE;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                    ValidateIssuerSigningKey = true
                };
            });
            services.AddSingleton<IOrderServices, OrdersService>();
           
            services.AddDbContext<OrderContext>();
            services.AddScoped<IDBRepository<Order>, DBRepository<Order>>();
            services.AddScoped<IDBRepository<Product>, DBRepository<Product>>();
            services.AddScoped<IDBRepository<User>, DBRepository<User>>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            app.UseDefaultFiles();
            app.UseMvc();
            app.UseAuthentication();
        }
    }
}
