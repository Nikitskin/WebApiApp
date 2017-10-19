using WebAPITestApp.Models;

namespace WebAPITestApp.Infrastructure.WebServices.AuthorizationService
{
    public interface IUserService
    {
        TokenResponse GetToken(string userName, string Password);
    }
}
