using BuddyGuard.Core.Contracts;
using BuddyGuard.Core.Data;
using BuddyGuard.Core.Data.Models;
using BuddyGuard.Core.Models;
using BuddyGuard.Core.Services;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace BuddyGuard.API.Controllers
{
    [Area("Shared")]
    public class LoginController : Controller
    {
        private IConfiguration _config;
        private SignInManager<User> signInManager;
        private UserManager<User> userManager;
        private BuddyguardDbContext dbContext;
        private IHttpContextAccessor contextAccessor;

        public LoginController(IConfiguration config, SignInManager<User> signInManager, UserManager<User> userManager, BuddyguardDbContext dbContext, IHttpContextAccessor contextAccessor)
        {
            _config = config;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.dbContext = dbContext;
            this.contextAccessor = contextAccessor;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            try
            {
                IActionResult response = Unauthorized();

                var user = await userManager.FindByNameAsync(login.Username);

                var role = (from users in dbContext.Users
                            where users.Id == user.Id
                            join usersRoles in dbContext.UserRoles on users.Id equals usersRoles.UserId
                            join roles in dbContext.Roles on usersRoles.RoleId equals roles.Id
                            select roles).First();

                var result = await signInManager.CheckPasswordSignInAsync(user, login.Password, false);

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

                    response = Ok(
                        new { token = tokenString, 
                        role = role.Name,
                        id = user.Id,
                        name = user.FirstName,
                        phone = user.PhoneNumber,
                        email = user.Email }
                    );
                    return response;
                }

                return response;
            }
            catch (Exception)
            {

                return Unauthorized();
            }
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult IsLoggedIn(string token)
        {
            try
            {
                var isInRole = User.IsInRole("User");
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

                return Ok(true);
            }
            catch
            {
                return Ok(false);
            }
        }

        public async Task<IActionResult> IsLoggedInAsUser(string token)
        {
            try
            {
                var isInRole = User.IsInRole("User");
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

                return Ok(true && isInRole);
            }
            catch
            {
                return Ok(false);
            }
        }
        
        public IActionResult IsLoggedInAsAdmin(string token)
        {
            try
            {
                var isInRole = User.IsInRole("Admin");
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

                return Ok(true && isInRole);
            }
            catch
            {
                return Ok(false);
            }
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
