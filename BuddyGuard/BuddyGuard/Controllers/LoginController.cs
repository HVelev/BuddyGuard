using BuddyGuard.Core.Contracts;
using BuddyGuard.Core.Data;
using BuddyGuard.Core.Data.Models;
using BuddyGuard.Core.Enums;
using BuddyGuard.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;
using System.Text;

namespace BuddyGuard.API.Controllers
{
    [Area("Shared")]
    public class LoginController : Controller
    {
        private UserManager<User> userManager;
        private BuddyguardDbContext dbContext;
        private ILoginService loginService;

        public LoginController(UserManager<User> userManager, BuddyguardDbContext dbContext, IHttpContextAccessor contextAccessor, ILoginService loginService)
        {
            this.userManager = userManager;
            this.dbContext = dbContext;
            this.loginService = loginService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            try
            {
                var user = await userManager.FindByNameAsync(login.Username);

                LoginDTO userDto = await loginService.Login(user, login.Password);

                return Ok(userDto);
            }
            catch (UnauthorizedAccessException)
            {

                return Unauthorized();
            }

            //try
            //{
            //    IActionResult response = Unauthorized();


            //    var role = (from users in dbContext.Users
            //                where users.Id == user.Id
            //                join usersRoles in dbContext.UserRoles on users.Id equals usersRoles.UserId
            //                join roles in dbContext.Roles on usersRoles.RoleId equals roles.Id
            //                select roles).First();

            //    var result = await signInManager.CheckPasswordSignInAsync(user, login.Password, false);

            //    if (result.Succeeded)
            //    {
            //        List<Claim> claims = new List<Claim>
            //        {
            //            new Claim(ClaimTypes.Role, role.Name)
            //        };

            //        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
            //        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //        var token = new JwtSecurityToken(_config["Jwt:Issuer"],
            //          _config["Jwt:Issuer"],
            //          claims,
            //          expires: DateTime.Now.AddMinutes(120),
            //          signingCredentials: credentials);

            //        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

            //        response = Ok(
            //            new { token = tokenString, 
            //            role = role.Name,
            //            id = user.Id,
            //            name = user.FirstName,
            //            phone = user.PhoneNumber,
            //            email = user.Email }
            //        );
            //        return response;
            //    }

            //    return response;
            //}
            //catch (Exception)
            //{
            //    return Unauthorized();
            //}
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult IsLoggedIn(string token)
        {
            bool result = loginService.IsLoggedIn(token);

            return Ok(result);
        }

        public async Task<IActionResult> IsLoggedInAsUser(string token)
        {
            var isInRole = User.IsInRole(nameof(RoleEnums.User));

            if (!isInRole)
            {
                return Ok(false);
            }

            bool result = loginService.IsLoggedIn(token);

            return Ok(result);
        }
        
        public IActionResult IsLoggedInAsAdmin(string token)
        {
            var isInRole = User.IsInRole(nameof(RoleEnums.Admin));

            if (!isInRole)
            {
                return Ok(false);
            }

            bool result = loginService.IsLoggedIn(token);

            return Ok(result);
        }
    }
}
