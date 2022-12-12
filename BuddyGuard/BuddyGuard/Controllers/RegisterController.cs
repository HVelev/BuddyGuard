using BuddyGuard.Core.Contracts;
using BuddyGuard.Core.Data;
using BuddyGuard.Core.Data.Models;
using BuddyGuard.Core.Models;
using BuddyGuard.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BuddyGuard.API.Controllers
{
    [Area("Shared")]
    public class RegisterController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly BuddyguardDbContext dbContext;
        private readonly INomenclatureService nomenclatureService;

        public RegisterController(UserManager<User> userManager, BuddyguardDbContext dbContext, INomenclatureService nomenclatureService)
        {
            this.userManager = userManager;
            this.dbContext = dbContext;
            this.nomenclatureService = nomenclatureService;
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

                await userManager.AddToRoleAsync(user, userModel.Role);

                dbContext.SaveChanges();

                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetRoles()
        {
            var result = nomenclatureService.RolesNomenclatures();

            return Ok(result);
        }
    }
}
