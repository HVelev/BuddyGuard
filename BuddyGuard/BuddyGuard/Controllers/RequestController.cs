using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Filters;

namespace BuddyGuard.Controllers
{
    public class RequestController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetRequest()
        {
            return Ok("Ok");
        }
    }
}
