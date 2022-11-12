using BuddyGuard.Core.Contracts;
using BuddyGuard.Core.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Filters;

namespace BuddyGuard.Controllers
{
    public class RequestController : Controller
    {
        private readonly IRequestService requestService;

        public RequestController(IRequestService requestService)
        {
            this.requestService = requestService;
        }

        [Authorize]
        [HttpPost]
        public IActionResult SubmitForm([FromBody] FormDTO form)
        {
            requestService.SubmitForm(form);

            return Ok();
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAllUnreadRequests()
        {
            var requests = requestService.GetAllUnreadRequests();

            return Ok(requests);
        }
    }
}
