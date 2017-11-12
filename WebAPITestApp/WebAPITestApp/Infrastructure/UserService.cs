using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using DBLayer.UnitOfWork;
using Microsoft.IdentityModel.Tokens;
using NLogger;
using WebAPITestApp.Models.AuthModels;
using System.Threading.Tasks;
using DBLayer.DbData;

namespace WebAPITestApp.Infrastructure
{
    public class UserService :  IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ILoggerService _logger;

        public UserService(IUnitOfWork unitOfWork, ILoggerService logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<string> GetToken(UserModel userModel)
        {
            var list = await _unitOfWork.UsersRepository.GetAll();
            var person = list.FirstOrDefault(user => user.UserName == userModel.UserName && user.Password == userModel.Password);

            if (person != null)
                return userModel.LastPasswordChangedDate.AddMinutes(1) < DateTime.Now
                    ? string.Format("User {0} has expired password", userModel.UserName)
                    : GetIdentity(userModel);

            _logger.Info(string.Format("{0} is not exists", userModel.UserName));
            return "Incorrect user credetials";
        }

        public async Task AddUser(UserModel userModel)
        {
            _unitOfWork.UsersRepository.Create(AutoMapper.Mapper.Map<User>(userModel));
            await _unitOfWork.Save();
        }

        public async Task UpdateUser(UserModel user)
        {
            _unitOfWork.UsersRepository.Update(AutoMapper.Mapper.Map<User>(user));
            await _unitOfWork.Save();
        }

        private string GetIdentity(UserModel userModel)
        {
            // TODO Your password in db should be encoded, so in this case you can't just compare password User entered and password from db.
            // You can either use EF identity db context to store users or find some nuget package and encode password by yourself.
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
    }
}
