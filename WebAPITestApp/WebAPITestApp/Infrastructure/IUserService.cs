using System.Threading.Tasks;
using WebAPITestApp.Models.AuthModels;

namespace WebAPITestApp.Infrastructure
{
    public interface IUserService
    {
        Task<string> GetToken(UserModel user);

        Task AddUser(UserModel user);

        Task UpdateUser(UserModel user);
    }
}
