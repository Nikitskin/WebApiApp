using Microsoft.AspNet.Identity.EntityFramework;

namespace WebAPITestApp.Infrastracture.Authorization
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext() : base("ShopConnection")
        {
            
        }
    }
}
