using BuddyGuard.Core.Contracts;
using BuddyGuard.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuddyGuard.API.Controllers
{
    public class BuddiesController : Controller
    {
        private readonly IBuddiesService service;

        public BuddiesController(IBuddiesService service)
        {
            this.service = service;
        }

        [Authorize]
        [HttpPost]
        public IActionResult Upload()
        {
            var file = Request.Form.Files[0].OpenReadStream();

            _ = Request.Form.Files;

            service.Upload("babfd", file);

            return Ok();
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetImages()
        {
            var result = service.GetImages();

            return Ok(result);
        }
    }
}
