using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using WebAPITestApp.DBLayer.DbData;
using WebAPITestApp.DBLayer.UnitOfWork;
using WebAPITestApp.NLogger;
using WebAPITestApp.Web.Models.AuthModels;

namespace WebAPITestApp.Web.Infrastructure
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
            var user = AutoMapper.Mapper.Map<User>(userModel);
            var person = list.FirstOrDefault(u => u.UserName == userModel.UserName && u.Password == user.Password);

            if (person != null)
                return person.LastPasswordChangedDate.AddDays(10) < DateTime.Now
                    ? string.Format("User {0} has expired password", person.UserName)
                    : GetIdentity(userModel);

            _logger.Info(string.Format("{0} is not exists", userModel.UserName));
            return "Incorrect user credetials";
        }

        public async Task AddUser(UserModel userModel)
        {
            _unitOfWork.UsersRepository.Create(AutoMapper.Mapper.Map<User>(userModel));
            await _unitOfWork.Save();
        }

        public async Task UpdateUser(UserModel userModel)
        {
            var user = AutoMapper.Mapper.Map<User>(userModel);
            var list = await _unitOfWork.UsersRepository.GetAll();
            var person = list.FirstOrDefault(u => u.UserName == user.UserName);
            if (person == null)
            {
                person.Password = user.Password;
                _unitOfWork.UsersRepository.Update(person);
                await _unitOfWork.Save();
            }
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
    }
}
