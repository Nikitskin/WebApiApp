using System.Threading.Tasks;
using WebAPITestApp.Models.AuthModels;

namespace WebAPITestApp.Infrastructure
{
    public interface IUserService
    {
        Task<TokenResponse> GetToken(string userName, string password);
    }
}
