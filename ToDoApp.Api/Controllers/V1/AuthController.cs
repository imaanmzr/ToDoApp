using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Application.Contracts.Identity;
using ToDoApp.Application.Models.Identity;

namespace ToDoApp.Api.Controllers.V1
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IAuthService authService;

		public AuthController(IAuthService authService)
        {
			this.authService = authService;
		}

		[HttpPost("login")]
		public async Task<ActionResult<AuthResponse>> Login(AuthRequest request)
		{
			return Ok(await authService.Login(request));
		}

		[HttpPost("register")]
		public async Task<ActionResult<RegistrationResponse>> Register(RegistrationRequest request)
		{
			return Ok(await authService.Register(request));
		}



    }
}
