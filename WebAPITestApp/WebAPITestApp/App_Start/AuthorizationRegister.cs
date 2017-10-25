using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using WebAPITestApp.Infrastructure.WebServices.AuthorizationService.AuthorizationConfig;

namespace WebAPITestApp.App_Start
{
    public static class AuthorizationRegister
    {
        public static void RegisterAuthorization(this IServiceCollection services)
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
    }
}
