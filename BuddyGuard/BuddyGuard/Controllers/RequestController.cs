using BuddyGuard.Core.Contracts;
using BuddyGuard.Core.Enums;
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


        public RequestController(IRequestService requestService, IUserService userService, INomenclatureService nomenclatureService)
        {
            this.requestService = requestService;
            this.userService = userService;
            this.nomenclatureService = nomenclatureService;
        }

        [Authorize(Roles = nameof(RoleEnum.User))]
        [HttpPost]
        public IActionResult SubmitForm([FromBody] EditRequestDTO form)
        {
            int id = requestService.SubmitForm(form);

            return Ok(id);
        }

        [Authorize(Roles = nameof(RoleEnum.User))]
        [HttpGet]
        public IActionResult GetAnimalTypes()
        {
            var result = nomenclatureService.AnimalTypesNomenclatures();

            return Ok(result);
        }

        [Authorize(Roles = nameof(RoleEnum.User))]
        [HttpGet]
        public IActionResult GetLocations()
        {
            var result = nomenclatureService.LocationsNomenclatures();

            return Ok(result);
        }

        [Authorize(Roles = nameof(RoleEnum.User))]
        [HttpGet]
        public IActionResult GetClientServices()
        {
            var result = nomenclatureService.ClientServicesNomenclatures();

            return Ok(result);
        }

        [Authorize(Roles = nameof(RoleEnum.User))]
        [HttpGet]
        public IActionResult GetSmallDogServices()
        {
            var result = nomenclatureService.SmallDogServicesNomenclatures();

            return Ok(result);
        }

        [Authorize(Roles = nameof(RoleEnum.User))]
        [HttpGet]
        public IActionResult GetSmallDogWalkLengths()
        {
            var result = nomenclatureService.SmallDogWalkLengthNomenclatures();

            return Ok(result);
        }

        [Authorize(Roles = nameof(RoleEnum.User))]
        [HttpGet]
        public IActionResult GetBigDogServices()
        {
            var result = nomenclatureService.BigDogServicesNomenclatures();

            return Ok(result);
        }
        
        [Authorize(Roles = nameof(RoleEnum.User))]
        [HttpGet]
        public IActionResult GetBigDogWalkLengths()
        {
            var result = nomenclatureService.BigDogWalkLengthNomenclatures();

            return Ok(result);
        }

        [Authorize(Roles = nameof(RoleEnum.User))]
        [HttpGet]
        public IActionResult GetCatServices()
        {
            var result = nomenclatureService.CatServicesNomenclatures();

            return Ok(result);
        }
    }
}
