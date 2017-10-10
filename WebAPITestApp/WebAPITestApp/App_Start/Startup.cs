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
            // TODO I wouldn't use Singleton because it creates one instance and use it all the time, what means that this instance won't die.

            services.AddDbContext<OrderContext>();
            services.AddScoped<IDbRepository<Order>, DbRepository<Order>>();
            services.AddScoped<IDbRepository<Product>, DbRepository<Product>>();
            services.AddScoped<IDbRepository<User>, DbRepository<User>>();
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
