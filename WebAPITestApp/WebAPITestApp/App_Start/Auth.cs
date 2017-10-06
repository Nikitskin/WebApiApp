using Microsoft.Owin;
using Owin;
using System;
using Microsoft.Owin.Security.OAuth;
using WebAPITestApp.Infrastracture.Authorization;

[assembly: OwinStartup(typeof(WebAPITestApp.Startup))]
namespace WebAPITestApp
{
    public partial class Startup
    {
        public void ConfigureAuth(IAppBuilder app)
        {
            OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromMinutes(10),
                Provider = new AuthorizationServerProvider()
            };

            // Token Generation
            app.UseOAuthAuthorizationServer(OAuthServerOptions);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
        }
    }
}
