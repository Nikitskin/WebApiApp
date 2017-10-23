﻿using System;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using System.Linq;
using System.Security.Claims;
using DBLayer.DbData;
using DBLayer.UnitOfWork;
using WebAPITestApp.Models;
using WebAPITestApp.Infrastructure.WebServices.AuthorizationService.AuthorizationConfig;
using System.IdentityModel.Tokens.Jwt;
using Logger;

namespace WebAPITestApp.Infrastructure.WebServices.AuthorizationService
{
    public class UserService : IUserService
    {
        private IUnitOfWork _unitOfWork;

        // TODO Why Logger is a property? I suppose it should be private as UnitOfWork and should be initialized from constructor as well. 
        public ILoggerService Logger { get; set; }

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public TokenResponse GetToken(string firstName, string password)
        {
            var identity = GetIdentity(firstName, password);

            if (identity == null)
            {
                Logger.Info("User inputed incorrect credentials");
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
            User person = _unitOfWork.UsersRepository.GetAll().Result.FirstOrDefault(x => x.FirstName == firstName && x.Password == password);
            // TODO Fix indents! It's not readable. Besides if you invert this if, you will lose one nesting level.
            if (person != null)
            {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, person.FirstName),
            };
            ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
            }
            return null;
        }
    }
}
