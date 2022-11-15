using BuddyGuard.Core.Contracts;
using BuddyGuard.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuddyGuard.API.Controllers
{
    public class ProcessRequestController : Controller
    {
        private readonly IProcessRequestService processRequestService;

        public ProcessRequestController(IProcessRequestService processRequestService)
        {
            this.processRequestService = processRequestService;
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAllUnreadRequests()
        {
            var requests = processRequestService.GetAllUnreadRequests();

            return Ok(requests);
        }
    }
}
