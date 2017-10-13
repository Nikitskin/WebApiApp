using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Newtonsoft.Json;
using System.Security.Claims;
using ServiceLayer.WebServices.AuthorizationService;
using ServiceLayer.WebServices.AuthorizationService.AuthorizationConfig;
using WebAPITestApp.Models;

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
            var tokenResponse = _userService.GetToken(userModel.UserName, userModel.Password);
            Response.StatusCode = tokenResponse.StatusCode;
            await Response.WriteAsync(tokenResponse.AccessToken);
        }
    }
}
