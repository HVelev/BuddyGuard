using BuddyGuard.Core.Contracts;
using BuddyGuard.Core.Data;
using BuddyGuard.Core.Data.Common;
using BuddyGuard.Core.Data.Models;
using BuddyGuard.Core.Exceptions;
using BuddyGuard.Core.Models;
using BuddyGuard.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http.Results;

namespace BuddyGuard.API.Controllers
{
    [Area("Shared")]
    public class RegisterController : Controller
    {
        private readonly IRegisterService service;
        private readonly INomenclatureService nomenclatureService;

        public RegisterController(IRegisterService service, IRepository repository, INomenclatureService nomenclatureService)
        {
            this.service = service;
            this.nomenclatureService = nomenclatureService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterDTO userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            try
            {
                await service.Register(userModel);

                return Ok();
            }
            catch (InvalidOperationException)
            {
                return UnprocessableEntity();
            }
            catch (PasswordException ex)
            {
                var codes = ex.ErrorCodes;

                return BadRequest(codes);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetRoles()
        {
            var result = nomenclatureService.RolesNomenclatures();

            return Ok(result);
        }
    }
}
