using DTOLib.AuthModels;

namespace WebAPITestApp.Infrastructure
{
    public interface IUserService
    {
        TokenResponse GetToken(string userName, string password);
    }
}
