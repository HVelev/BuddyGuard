using BuddyGuard.Core.Contracts;
using BuddyGuard.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity.Core.Metadata.Edm;

namespace BuddyGuard.API.Controllers
{
    [Area("Shared")]
    public class InquiryController : Controller
    {
        private readonly IInquiryService service;

        public InquiryController(IInquiryService service)
        {
            this.service = service;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult SendInquiry([FromBody] InquiryDTO data)
        {
            if (ModelState.IsValid)
            {
                service.SendInquiry(data);

                return Ok();
            }

            return BadRequest();
        }
    }
}
