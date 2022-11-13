using BuddyGuard.Core.Contracts;
using BuddyGuard.Core.Data.Models;
using BuddyGuard.Core.Models;
using BuddyGuard.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;

namespace BuddyGuard.API.Controllers
{
    public class LoginController : Controller
    {
        private IConfiguration _config;
        private SignInManager<User> signInManager;
        private UserManager<User> userManager;

        public LoginController(IConfiguration config, SignInManager<User> signInManager, UserManager<User> userManager)
        {
            _config = config;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            IActionResult response = Unauthorized();

            var user = await userManager.FindByNameAsync(login.Username);

            var result = await signInManager.CheckPasswordSignInAsync(user, login.Password, false);

            if (result.Succeeded)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                  _config["Jwt:Issuer"],
                  null,
                  expires: DateTime.Now.AddMinutes(120),
                  signingCredentials: credentials);

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
                response = Ok(new { token = tokenString, user = user });
            }

            return response;
        }

        public static string GetMD5(string str)
        {
            HMACMD5 md5 = new HMACMD5();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }
    }
}
