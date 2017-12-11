using System;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using WebAPITestApp.DBLayer.Contexts;
using WebAPITestApp.DBLayer.DbData;

namespace WebAPITestApp.Web
{
    public static class AuthorizationServiceExtension
    {
        public static void RegisterAuthorization(this IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(opt =>
                {
                    opt.LoginPath = PathString.FromUriComponent("/Home/Index");
                });
            services.AddIdentity<User, IdentityRole>().
                AddEntityFrameworkStores<OrderContext>().
                AddDefaultTokenProviders();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredUniqueChars = 3;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;
                options.Cookie.Expiration = TimeSpan.FromDays(150);
                options.LoginPath = "/Home/Index"; 
                options.LogoutPath = "/Home/Index"; 
                options.SlidingExpiration = true;
            });
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(options =>
            //    {
            //        options.Configuration = new OpenIdConnectConfiguration();
            //        options.RequireHttpsMetadata = false;
            //        options.Audience = AuthOptions.AUDIENCE;
            //        options.Authority = AuthOptions.AUDIENCE;
            //        options.TokenValidationParameters = new TokenValidationParameters
            //        {
            //            ValidateAudience = false,
            //            ValidateIssuer = false,
            //            ValidateLifetime = true,
            //            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
            //            ValidateIssuerSigningKey = true
            //        };

            //        options.IncludeErrorDetails = true;
            //    });
            services.AddTransient<UserManager<User>>();
            services.AddTransient<SignInManager<User>>();
        }
    }
}
