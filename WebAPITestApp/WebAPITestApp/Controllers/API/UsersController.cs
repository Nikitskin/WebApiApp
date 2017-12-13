using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAPITestApp.Web.Infrastructure;
using WebAPITestApp.Web.Infrastructure.Attributes;
using WebAPITestApp.Web.Models.AuthModels;

namespace WebAPITestApp.Web.Controllers.API
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

        [HttpPut("{id}")]
        public async Task UpdateUser(string id, [Bind("Password")]UserModel user)
        {
            user.Id = Guid.Parse(id);
            await _userService.UpdateUser(user);
        }

        [HttpPost("token")]
        [ValidateModel]
        public async Task<string> Token([FromForm]UserModel userModel)
        {
            var result = await _userService.GetToken(userModel);
            return result ?? "Incorrect credetionals entered";
        }
    }
}
