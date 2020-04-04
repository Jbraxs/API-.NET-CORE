using Contracts;
using Entities.ExtendedModels;
using Entities.Helpers;
using Entities.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ProyectWeight.Users
{
    public class UsersToken :  IUsers
    {
            public AppSettings _appSettings;

            private List<CorpCustomersExtended> _users = new List<CorpCustomersExtended>
            {
                 new CorpCustomersExtended{ IdCustomers = 1, FirstName ="Test12345", LastName = "Test12345", Password = "Test12345", Email = "test@test.com" }
            };

            public UsersToken(IOptions<AppSettings> appSettings)
            {
                _appSettings = appSettings.Value;
            }

            public CorpCustomersExtended Authenticate(string Email, string Password)
            {
                var user = _users.SingleOrDefault(x => x.Email == Email && x.Password == Password);

                // return null if user not found
                if (user == null)
                {
                    return null;
                }

                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.IdCustomers.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);

                // remove password before returning
                user.Password = null;

                return user;
            }
    }
}
