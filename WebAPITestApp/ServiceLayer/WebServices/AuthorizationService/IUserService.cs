using ServiceLayer.Models;

namespace ServiceLayer.WebServices.AuthorizationService
{
    public interface IUserService
    {
        TokenResponse GetToken(string userName, string Password);
    }
}
