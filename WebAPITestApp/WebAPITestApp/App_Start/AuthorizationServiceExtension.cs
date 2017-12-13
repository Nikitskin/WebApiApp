using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using WebAPITestApp.DBLayer.Contexts;
using WebAPITestApp.DBLayer.DbData;
using WebAPITestApp.Web.Infrastructure;

namespace WebAPITestApp.Web
{
    public static class AuthorizationServiceExtension
    {
        public static void RegisterAuthorization(this IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme);
            services.AddAuthorization();
            services.AddIdentity<User, IdentityRole<Guid>>(options =>
                {
                    options.Password.RequireDigit = false;
                    options.Password.RequiredLength = 3;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                }).
                AddEntityFrameworkStores<OrderContext>().
                AddDefaultTokenProviders().
                AddUserStore<UserStore<User, IdentityRole<Guid>, OrderContext, Guid>>().
                AddRoleStore<RoleStore<IdentityRole<Guid>, OrderContext, Guid>>();

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
                });
        }
    }
}
