using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebAPITestApp
{
    public class AuthOptions
    {
        public const string ISSUER = "AuthServer"; 
        public const string AUDIENCE = "http://localhost:6160"; 
        const string KEY = "supersecretkeyforme_123!";  // TODO Where is access modifier?
        public const int LIFETIME = 1;
        public static SymmetricSecurityKey GetSymmetricSecurityKey() => new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
    }
}
