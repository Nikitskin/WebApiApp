using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebAPITestApp
{
    public class AuthOptions
    {
        public const string AUDIENCE = "http://localhost:6160";
        public const string KEY = "supersecretkeyforme_123!";  
        public const int LIFETIME = 1;
        public static SymmetricSecurityKey GetSymmetricSecurityKey() => new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
    }
}
