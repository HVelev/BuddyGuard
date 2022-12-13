using BuddyGuard.Core.Contracts;
using BuddyGuard.Core.Data.Models;
using BuddyGuard.Core.Enums;
using BuddyGuard.Core.Models;
using BuddyGuard.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuddyGuard.API.Controllers
{
    [Area("Admin")]
    public class ProcessRequestController : Controller
    {
        private readonly IProcessRequestService processRequestService;

        private readonly IMailService mailService;

        public ProcessRequestController(IProcessRequestService processRequestService, IMailService mailService)
        {
            this.processRequestService = processRequestService;
            this.mailService = mailService;
        }


        [Authorize(Roles = nameof(RoleEnums.Admin))]
        [HttpGet]
        public IActionResult GetAllUnreadRequests()
        {
            var result = processRequestService.GetAllRequests(true, false);

            return Ok(result);
        }

        [Authorize(Roles = nameof(RoleEnums.Admin))]
        [HttpGet]
        public IActionResult GetAllRequests()
        {
            var result = processRequestService.GetAllRequests(false, false);

            return Ok(result);
        }
        
        [Authorize(Roles = nameof(RoleEnums.Admin))]
        [HttpGet]
        public IActionResult GetAllAcceptedRequests()
        {
            var result = processRequestService.GetAllRequests(false, true);

            return Ok(result);
        }

        [Authorize(Roles = nameof(RoleEnums.Admin))]
        [HttpGet]
        public IActionResult GetRequest([FromQuery] int requestId)
        {
            RequestDTO result = processRequestService.GetRequest(requestId);

            return Ok(result);
        }

        [Authorize(Roles = nameof(RoleEnums.Admin))]
        [HttpPut]
        public IActionResult MarkRequestAsRead([FromQuery] int id)
        {
            processRequestService.MarkRequestAsRead(id);

            return Ok();
        }

        [Authorize(Roles = nameof(RoleEnums.Admin))]
        [HttpPut]
        public IActionResult AcceptRequest([FromQuery] int id)
        {
            string mail = processRequestService.AcceptRequest(id);

            mailService.SendConfirmationEmail(mail);

            return Ok();
        }

        [Authorize(Roles = nameof(RoleEnums.Admin))]
        [HttpDelete]
        public IActionResult RejectRequest([FromQuery] int id)
        {
            string mail = processRequestService.DeleteRequest(id);

            mailService.SendRejectionEmail(mail);

            return Ok();
        }

        [Authorize(Roles = nameof(RoleEnums.Admin))]
        [HttpDelete]
        public IActionResult DeleteRequest([FromQuery] int id)
        {
            processRequestService.DeleteRequest(id);

            return Ok();
        }
    }
}
