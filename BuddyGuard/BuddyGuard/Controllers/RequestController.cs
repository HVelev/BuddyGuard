using BuddyGuard.Core.Contracts;
using BuddyGuard.Core.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Web.Http.Filters;

namespace BuddyGuard.Controllers
{
    public class RequestController : Controller
    {
        private readonly IRequestService requestService;

        private readonly IUserService userService;

        private readonly INomenclatureService nomenclatureService;

        public RequestController(IRequestService requestService, IUserService userService, INomenclatureService nomenclatureService)
        {
            this.requestService = requestService;
            this.userService = userService;
            this.nomenclatureService = nomenclatureService;
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
        public IActionResult GetAllUnreadRequests()
        {
            var result = requestService.GetAllUnreadRequests();

            return Ok(result);
        }
    }
}
