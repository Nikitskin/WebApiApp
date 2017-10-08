using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebAPITestApp
{
    public class AuthOptions
    {
        public const string ISSUER = "AuthServer"; 
        public const string AUDIENCE = "http://localhost:51884/"; 
        const string KEY = "key_!4";  
        public const int LIFETIME = 1;
        public static SymmetricSecurityKey GetSymmetricSecurityKey() => new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
    }
}
