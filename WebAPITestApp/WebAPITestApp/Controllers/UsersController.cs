using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using NLogger;
using WebAPITestApp.Infrastructure.Attributes;
using WebAPITestApp.Infrastructure;
using WebAPITestApp.Models.AuthModels;

namespace WebAPITestApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService, ILoggerService logger)
        {
            _userService = userService;
        }

        [HttpPost("/token")]
        [ValidateModel]
        public async Task Token([FromForm]UserModel userModel)
        {
            var tokenResponse = await _userService.GetToken(userModel.UserName, userModel.Password);
            Response.StatusCode = tokenResponse.StatusCode;
            await Response.WriteAsync(tokenResponse.AccessToken);
        }
    }
}
