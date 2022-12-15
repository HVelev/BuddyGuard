using BuddyGuard.Core.Contracts;
using BuddyGuard.Core.Data;
using BuddyGuard.Core.Data.Models;
using BuddyGuard.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BuddyGuard.Core.Services
{
    public class LoginService : ILoginService
    {
        private BuddyguardDbContext db;

        private IConfiguration _config;

        SignInManager<User> _signInManager;

        public LoginService(BuddyguardDbContext db, IConfiguration _config, SignInManager<User> _signInManager)
        {
            this.db = db;
            this._config = _config;
            this._signInManager = _signInManager;
        }

        public async Task<LoginDTO> Login(User login, string password)
        {
            try
            {
                var role = (from users in db.Users
                            where users.Id == login.Id
                            join usersRoles in db.UserRoles on users.Id equals usersRoles.UserId
                            join roles in db.Roles on usersRoles.RoleId equals roles.Id
                            select roles).First();

                var result = await _signInManager.CheckPasswordSignInAsync(login, password, false);

                if (result.Succeeded)
                {
                    List<Claim> claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Role, role.Name)
                    };

                    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
                    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                      _config["Jwt:Issuer"],
                      claims,
                      expires: DateTime.Now.AddMinutes(120),
                      signingCredentials: credentials);

                    var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                    return new LoginDTO
                    {
                        Token = tokenString,
                        Role = role.Name,
                        Id = login.Id,
                        FirstName = login.FirstName,
                        LastName = login.LastName,
                        Phone = login.PhoneNumber,
                        Email = login.Email
                    };
                }

                throw new UnauthorizedAccessException();
            }
            catch (Exception)
            {
                throw new UnauthorizedAccessException();
            }
        }

        public bool IsLoggedIn(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_config["Jwt:SecretKey"]);
                var securityKey = Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]);
                var claim = tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidAudience = _config["Jwt:Audience"],
                    ValidIssuer = _config["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(securityKey),
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
