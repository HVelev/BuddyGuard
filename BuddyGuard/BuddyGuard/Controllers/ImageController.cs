using BuddyGuard.Core.Contracts;
using BuddyGuard.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace BuddyGuard.API.Controllers
{
    [Area("Shared")]
    public class ImageController : Controller
    {
        private readonly IImageService imageService;

        public ImageController(IImageService imageService)
        {
            this.imageService = imageService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AddImage([FromForm] EditImageDTO image)
        {
            await imageService.AddImage(image);

            return Ok();
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetImages()
        {
            var images = await imageService.GetImages();

            return Ok(images);
        }
        
        [AllowAnonymous]
        [HttpDelete]
        public async Task<IActionResult> DeleteImage([FromQuery] string key)
        {
            var response = imageService.DeleteImage(key);

            response.Con

            return Ok();
        }
    }
}
