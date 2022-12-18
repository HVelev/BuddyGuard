using BuddyGuard.Core.Contracts;
using BuddyGuard.Core.Data;
using BuddyGuard.Core.Data.Common;
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
        private readonly IRepository repository;
        private readonly INomenclatureService nomenclatureService;

        public RegisterController(UserManager<User> userManager, IRepository repository, INomenclatureService nomenclatureService)
        {
            this.userManager = userManager;
            this.repository = repository;
            this.nomenclatureService = nomenclatureService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterDTO userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                var doesUserExist = repository.All<User>().Where(x => x.Email == userModel.Email || x.UserName == userModel.Username).Count() > 0;

                if (doesUserExist)
                {
                    return UnprocessableEntity();
                }

                User user = new User
                {
                    UserName = userModel.Username,
                    Email = userModel.Email,
                    FirstName = userModel.FirstName,
                    LastName = userModel.LastName,
                    PhoneNumber = userModel.Phone
                };

                var result = await userManager.CreateAsync(user, userModel.Password);

                await userManager.AddToRoleAsync(user, userModel.Role);

                repository.SaveChanges();

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
