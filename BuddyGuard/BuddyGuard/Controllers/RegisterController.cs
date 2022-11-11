using BuddyGuard.Core.Data.Models;
using BuddyGuard.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BuddyGuard.API.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<User> userManager;

        public RegisterController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterDTO userModel)
        {
            User user = new User
            {
                UserName = userModel.Username
            };

            var result = await userManager.CreateAsync(user, userModel.Password);
            return Ok();
        }
    }
}
