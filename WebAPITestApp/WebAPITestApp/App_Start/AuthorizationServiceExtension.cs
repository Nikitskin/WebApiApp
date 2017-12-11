using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using WebAPITestApp.DBLayer.DbData;
using WebAPITestApp.Web.Infrastructure;

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
            services.AddAuthorization();
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
