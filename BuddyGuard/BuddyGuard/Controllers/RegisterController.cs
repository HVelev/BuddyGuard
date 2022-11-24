using BuddyGuard.Core.Data;
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
        private readonly BuddyguardDbContext dbContext;

        public RegisterController(UserManager<User> userManager, BuddyguardDbContext dbContext)
        {
            this.userManager = userManager;
            this.dbContext = dbContext;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterDTO userModel)
        {
            try
            {
                var doesUserExist = dbContext.Users.Where(x => x.Email == userModel.Email).Count() > 0;

                if (doesUserExist)
                {
                    return UnprocessableEntity();
                }

                User user = new User
                {
                    UserName = userModel.Username,
                    Email = userModel.Email,
                    Address = userModel.Address,
                    FirstName = userModel.FirstName,
                    LastName = userModel.LastName,
                    PhoneNumber = userModel.Phone
                };

                var result = await userManager.CreateAsync(user, userModel.Password);

                IdentityRole role = dbContext.Roles.Where(x => x.Name == userModel.Role).First();

                dbContext.UserRoles.Add(new IdentityUserRole<string>
                {
                    RoleId = role.Id,
                    UserId = user.Id
                });

                dbContext.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
