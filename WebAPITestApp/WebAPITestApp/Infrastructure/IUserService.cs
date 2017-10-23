using WebAPITestApp.Models;

namespace WebAPITestApp.Infrastructure.WebServices.AuthorizationService
{
    public interface IUserService
    {
        // TODO fix naming
        TokenResponse GetToken(string userName, string Password);
    }
}
