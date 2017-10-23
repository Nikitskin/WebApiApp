using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WebAPITestApp.Models;
using WebAPITestApp.Infrastructure.WebServices.AuthorizationService;

namespace WebAPITestApp.Controllers
{
    public class UsersController : Controller
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpPost("/token")]
        public async Task Token([FromForm]UserModel userModel)
        {
            // TODO You can write if(...) { return; } and you will lose one nesting level
            if (ModelState.IsValid)
            {
                var tokenResponse = _userService.GetToken(userModel.UserName, userModel.Password);
                Response.StatusCode = tokenResponse.StatusCode;
                await Response.WriteAsync(tokenResponse.AccessToken);
            }
        }
    }
}
