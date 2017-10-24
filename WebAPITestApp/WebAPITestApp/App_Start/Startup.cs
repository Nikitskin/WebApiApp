using AutoMapper;
using DBLayer.Contexts;
using DBLayer.DbData;
using DBLayer.DBRepository;
using DBLayer.UnitOfWork;
using Logger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using ServiceLayer.DatabaseServices.Orders;
using System;
using WebAPITestApp.Infrastructure;
using WebAPITestApp.Infrastructure.WebServices.AuthorizationService.AuthorizationConfig;

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
                RegisterAuthorization(services);
                RegisterDatabase(services);
                services.AddMvc(options =>
                {
                    options.Filters.Add(typeof(GlobalNLogExceptionFilter));
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

        private void RegisterAuthorization(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.Configuration = new OpenIdConnectConfiguration();
                    options.RequireHttpsMetadata = false;
                    options.Audience = AuthOptions.AUDIENCE;
                    options.Authority = AuthOptions.AUDIENCE;
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        ValidateLifetime = true,
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true
                    };

                    options.IncludeErrorDetails = true;
                    options.Events = new JwtBearerEvents
                    {
                        OnAuthenticationFailed = f => f.Response.WriteAsync(f.Exception.ToString())
                    };
                });
        }

        private void RegisterDatabase(IServiceCollection services)
        {
            services.AddScoped<IOrdersService, OrdersService>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<DbContext, OrderContext>();
            services.AddDbContext<OrderContext>(opt =>
                opt.UseSqlServer(Configuration.GetSection("ShopConnection:ConnectionString").Value));

            services.AddScoped<IDbRepository<Order>, DbRepository<Order>>();
            services.AddScoped<IDbRepository<Product>, DbRepository<Product>>();
            services.AddScoped<IDbRepository<User>, DbRepository<User>>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
