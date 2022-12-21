using BuddyGuard.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuddyGuard.API.Controllers
{
    [Area("Admin")]
    public class NotificationController : Controller
    {
        private readonly INotificationService service;

        public NotificationController(INotificationService service)
        {
            this.service = service;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult GetNotifications()
        {
            var result = service.GetNotifications();

            return Ok(result);
        }
    }
}
