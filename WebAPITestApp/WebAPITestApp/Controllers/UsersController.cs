using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using NLogger;
using WebAPITestApp.Infrastructure;
using WebAPITestApp.Models.AuthModels;

namespace WebAPITestApp.Controllers
{
    public class UsersController : Controller
    {
        private IUserService _userService;
        private readonly ILoggerService _logger;

        public UsersController(IUserService userService, ILoggerService logger)
        {
            _userService = userService;
            _logger = logger;
        }
        
        [HttpPost("/token")]
        public async Task Token([FromForm]UserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                _logger.Info("User entered incorect model for token action method model - ", userModel);
                return;
            }
            var tokenResponse = await _userService.GetToken(userModel.UserName, userModel.Password);
            Response.StatusCode = tokenResponse.StatusCode;
            await Response.WriteAsync(tokenResponse.AccessToken);
        }
    }
}
