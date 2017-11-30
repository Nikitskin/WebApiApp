using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPITestApp.NLogger;
using WebAPITestApp.Web.Infrastructure;
using WebAPITestApp.Web.Infrastructure.Attributes;
using WebAPITestApp.Web.Models.AuthModels;

namespace WebAPITestApp.Web.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService, ILoggerService logger)
        {
            _userService = userService;
        }

        //todo should i add authorization?
        [HttpPost]
        [ValidateModel]
        public async Task AddUser([FromForm]UserModel user)
        {
            await _userService.AddUser(user);
        }

        [HttpPut]
        public async Task UpdateUser(UserModel user)
        {
            await _userService.UpdateUser(user);
        }

        [HttpPost("token")]
        [ValidateModel]
        public async Task<string> Token([FromForm]UserModel userModel)
        {
             return await _userService.GetToken(userModel);
        }
    }
}
