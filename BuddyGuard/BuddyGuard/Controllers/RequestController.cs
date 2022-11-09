using BuddyGuard.Core.Contracts;
using BuddyGuard.Core.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Filters;

namespace BuddyGuard.Controllers
{
    public class RequestController : ControllerBase
    {
        private readonly IRequestService requestService;

        public RequestController(IRequestService requestService)
        {
            this.requestService = requestService;
        }

        [HttpPost]
        public IActionResult SubmitForm([FromBody] FormDTO form)
        {
            requestService.SubmitForm(form);

            return Ok();
        }
    }
}
