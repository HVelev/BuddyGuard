﻿using BuddyGuard.Core.Contracts;
using BuddyGuard.Core.Models;
using BuddyGuard.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuddyGuard.Controllers
{
    [Area("User")]
    public class RequestController : Controller
    {
        private readonly IRequestService requestService;

        private readonly IUserService userService;

        private readonly INomenclatureService nomenclatureService;

        private readonly IMailService mailService;

        public RequestController(IRequestService requestService, IUserService userService, INomenclatureService nomenclatureService, IMailService mailService)
        {
            this.requestService = requestService;
            this.userService = userService;
            this.nomenclatureService = nomenclatureService;
            this.mailService = mailService;
        }

        [Authorize]
        [HttpPost]
        public IActionResult SubmitForm([FromBody] EditRequestDTO form)
        {
            requestService.SubmitForm(form);

            return Ok();
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetRequest([FromQuery] int requestId)
        {
            RequestDTO result = requestService.GetRequest(requestId);

            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAnimalTypes()
        {
            var result = nomenclatureService.AnimalTypesNomenclatures();

            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetLocations()
        {
            var result = nomenclatureService.LocationsNomenclatures();

            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetClientServices()
        {
            var result = nomenclatureService.ClientServicesNomenclatures();

            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetSmallDogServices()
        {
            var result = nomenclatureService.SmallDogServicesNomenclatures();

            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetSmallDogWalkLengths()
        {
            var result = nomenclatureService.SmallDogWalkLengthNomenclatures();

            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetBigDogServices()
        {
            var result = nomenclatureService.BigDogServicesNomenclatures();

            return Ok(result);
        }
        
        [Authorize]
        [HttpGet]
        public IActionResult GetBigDogWalkLengths()
        {
            var result = nomenclatureService.BigDogWalkLengthNomenclatures();

            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetCatServices()
        {
            var result = nomenclatureService.CatServicesNomenclatures();

            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAllRequests()
        {
            var result = requestService.GetAllRequests(false);

            return Ok(result);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAllUnreadRequests()
        {
            var result = requestService.GetAllRequests(true);

            return Ok(result);
        }

        [Authorize]
        [HttpPut]
        public IActionResult MarkRequestAsRead([FromQuery] int id)
        {
            requestService.MarkRequestAsRead(id);

            return Ok();
        }

        [Authorize]
        [HttpPut]
        public IActionResult AcceptRequest([FromQuery] int id)
        {
            var email = requestService.AcceptRequest(id);

            mailService.SendConfirmationEmail(email);

            return Ok();
        }

        [Authorize]
        [HttpDelete]
        public IActionResult RejectRequest([FromQuery] int id)
        {
            var email = requestService.DeleteRequest(id);

            mailService.SendRejectionEmail(email);

            return Ok();
        }

        [Authorize]
        [HttpDelete]
        public IActionResult DeleteRequest([FromQuery] int id)
        {
            requestService.DeleteRequest(id);

            return Ok();
        }
    }
}
