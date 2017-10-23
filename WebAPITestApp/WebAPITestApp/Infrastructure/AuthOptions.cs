using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace WebAPITestApp.Infrastructure.WebServices.AuthorizationService.AuthorizationConfig
{
    public class AuthOptions
    {
        public const string AUDIENCE = "http://localhost:6160";
        public const string KEY = "supersecretkeyforme_123!";
        public const int LIFETIME = 1;

        public static SymmetricSecurityKey GetSymmetricSecurityKey() => new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
    }
}
