using System.Threading.Tasks;
using WebAPITestApp.Web.Models.AuthModels;

namespace WebAPITestApp.Web.Infrastructure
{
    public interface IUserService
    {
        Task<string> GetToken(UserModel user);

        Task AddUser(UserModel user);

        Task UpdateUser(UserModel user);
    }
}
