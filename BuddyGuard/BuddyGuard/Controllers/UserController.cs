using BuddyGuard.Core.Contracts;
using BuddyGuard.Core.Models;
using BuddyGuard.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuddyGuard.API.Controllers
{
    [Area("Shared")]
    public class UserController : Controller
    {
        private readonly IUserService service;

        public UserController(IUserService service)
        {
            this.service = service;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetUser([FromQuery] string id)
        {
            var currentUser = this.HttpContext.User;

            UserDTO user = service.GetUser(id);

            return Ok(user);
        }
    }
}
