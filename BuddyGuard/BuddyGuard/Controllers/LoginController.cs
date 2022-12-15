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
        private ILoginService loginService;

        public LoginController(UserManager<User> userManager, BuddyguardDbContext dbContext, IHttpContextAccessor contextAccessor, ILoginService loginService)
        {
            this.userManager = userManager;
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
