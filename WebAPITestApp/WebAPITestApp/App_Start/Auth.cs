using Microsoft.AspNetCore.Builder;
using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(WebAPITestApp.Startup))]
namespace WebAPITestApp.App_Start
{
    public partial class Startup
    {
        public void ConfigureAuth(IApplicationBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);
            //app.UseWebApi(config);
        }
    }
}
