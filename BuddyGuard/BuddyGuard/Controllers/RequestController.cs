using BuddyGuard.Core.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Filters;

namespace BuddyGuard.Controllers
{
    public class RequestController : ControllerBase
    {
        [HttpPost]
        public IActionResult SubmitForm([FromBody] FormDTO form)
        {
            return Ok("Ok");
        }
    }
}
