using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPITestApp.Infrastructure.Attributes;
using WebAPITestApp.Infrastructure;
using WebAPITestApp.Models.AuthModels;

namespace WebAPITestApp.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        //todo should i add authorization?
        [HttpPost("AddUser")]
        [ValidateModel]
        public async Task AddUser([FromForm]UserModel user)
        {
            await _userService.AddUser(user);
        }

        [HttpPut("UpdateUser/{id}")]
        public async Task UpdateUser(string id, [Bind("Password")]UserModel user)
        {
            user.Id = id;
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
