using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using WebAPITestApp.DBLayer.DbData;
using WebAPITestApp.DBLayer.UnitOfWork;
using WebAPITestApp.NLogger;
using WebAPITestApp.Web.Models.AuthModels;

namespace WebAPITestApp.Web.Infrastructure
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILoggerService _logger;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserService(IUnitOfWork unitOfWork, ILoggerService logger, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<string> GetToken(UserModel userModel)
        {
            var list = await _unitOfWork.UsersRepository.GetAll();
            var user = AutoMapper.Mapper.Map<User>(userModel);
            var person = list.FirstOrDefault(u => u.UserName == userModel.UserName && u.PasswordHash == user.PasswordHash);

            if (person != null)
                return person.LastPasswordChangedDate.AddDays(10) < DateTime.Now
                    ? string.Format("User {0} has expired password", person.UserName)
                    : GetIdentity(userModel);

            _logger.Info(string.Format("{0} is not exists", userModel.UserName));
            return null;
        }

        public async Task<IdentityResult> AddUser(UserModel userModel)
        {
            var result = await _userManager.CreateAsync(AutoMapper.Mapper.Map<User>(userModel), userModel.Password);
            //_unitOfWork.UsersRepository.Create(AutoMapper.Mapper.Map<User>(userModel));
            await _unitOfWork.Save();
            return result;
        }

        public async Task SignIn(UserModel user)
        {
            await _signInManager.SignInAsync(AutoMapper.Mapper.Map<User>(user), false);
        }

        //todo change update according to manager
        public async Task UpdateUser(UserModel user)
        {
            _unitOfWork.UsersRepository.Update(AutoMapper.Mapper.Map<User>(user));
            await _unitOfWork.Save();
        }

        private string GetIdentity(UserModel userModel)
        {
            var claimsIdentity = new ClaimsIdentity(new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, userModel.UserName),
                }, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            var jwt = new JwtSecurityToken(
                notBefore: DateTime.UtcNow,
                claims: claimsIdentity.Claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromHours(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public async Task<SignInResult> Login(UserModel model)
        {
            return await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
        }

        public async Task LogOff()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
