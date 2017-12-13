using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WebAPITestApp.Web.Models.AuthModels;

namespace WebAPITestApp.Web.Infrastructure
{
    public interface IUserService
    {
        Task<string> GetToken(UserModel user);

        Task<IdentityResult> AddUser(UserModel user);

        Task UpdateUser(UserModel user);

        Task<ClaimsPrincipal> Authenticate(UserModel model);

        Task LogOff();
    }
}
