using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using DBLayer.UnitOfWork;
using Microsoft.IdentityModel.Tokens;
using NLogger;
using WebAPITestApp.Models.AuthModels;

namespace WebAPITestApp.Infrastructure
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ILoggerService _logger;

        public UserService(IUnitOfWork unitOfWork, ILoggerService logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public TokenResponse GetToken(string firstName, string password)
        {
            var identity = GetIdentity(firstName, password);

            if (identity == null)
            {
                _logger.Info("User inputed incorrect credentials");
                return new TokenResponse
                {
                    StatusCode = 200,
                    AccessToken = "Invalid username or password."
                };
            }

            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(TimeSpan.FromHours(AuthOptions.LIFETIME)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            return new TokenResponse
            {
                StatusCode = 200,
                AccessToken = new JwtSecurityTokenHandler().WriteToken(jwt)
            };
        }

        private ClaimsIdentity GetIdentity(string firstName, string password)
        {
            // TODO Your password in db should be encoded, so in this case you can't just compare password User entered and password from db.
            // You can either use EF identity db context to store users or find some nuget package and encode password by yourself.
            var person = _unitOfWork.UsersRepository.GetAll().Result.FirstOrDefault(x => x.FirstName == firstName && x.Password == password);
            if (person == null) return null;

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, person.FirstName),
            };
            var claimsIdentity = new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }
    }
}
