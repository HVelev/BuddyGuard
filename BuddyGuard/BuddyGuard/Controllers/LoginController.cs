using BuddyGuard.Core.Contracts;
using BuddyGuard.Core.Data.Models;
using BuddyGuard.Core.Enums;
using BuddyGuard.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BuddyGuard.API.Controllers
{
    [Area("Shared")]
    public class LoginController : Controller
    {
        private UserManager<User> userManager;
        private ILoginService loginService;

        public LoginController(UserManager<User> userManager, ILoginService loginService)
        {
            this.userManager = userManager;
            this.loginService = loginService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDTO login)
        {
            if (ModelState.IsValid)
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

            return Unauthorized();
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult IsLoggedIn(string token)
        {
            bool result = loginService.IsLoggedIn(token);

            return Ok(result);
        }

        public IActionResult IsLoggedInAsUser(string token)
        {
            var isInRole = User.IsInRole(nameof(RoleEnum.User));

            if (!isInRole)
            {
                return Ok(false);
            }

            bool result = loginService.IsLoggedIn(token);

            return Ok(result);
        }
        
        public IActionResult IsLoggedInAsAdmin(string token)
        {
            var isInRole = User.IsInRole(nameof(RoleEnum.Admin));

            if (!isInRole)
            {
                return Ok(false);
            }

            bool result = loginService.IsLoggedIn(token);

            return Ok(result);
        }
    }
}
