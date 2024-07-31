using Microsoft.AspNetCore.Mvc;
using Vimenpaq.Core.Application.DTOs.Account;
using Vimenpaq.Core.Application.Interfaces.Services;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace Vimenpaq.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [SwaggerTag("Authentication")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpPost("authenticate")]
        [Consumes(MediaTypeNames.Application.Xml)]
        [Produces(MediaTypeNames.Application.Xml)]
        [SwaggerOperation(
            Summary = "User Login",
            Description = "Authenticates a user in the system and returns a JWT"
        )]
        public async Task<IActionResult> AuthenticateAsync([FromBody] AuthenticationRequest request)
        {
            return Ok(await _accountService.AuthenticateAsync(request));
        }
    }
}
