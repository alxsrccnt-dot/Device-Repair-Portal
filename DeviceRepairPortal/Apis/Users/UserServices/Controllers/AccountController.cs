using Application.ChangeUserClaim;
using Application.Login;
using Application.Register;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UserServices.Controllers;

[ApiController]
[Route("api/auth")]
public class AccountController(IMediator mediator) : Controller
{
	[AllowAnonymous]
	[HttpPost("login")]
	public async Task<IActionResult> Login(AuthenticationRequest request)
	{
		var token = await mediator.Send(new LoginCommand(request));
		return Ok(token);
	}

	[AllowAnonymous]
	[HttpPost("register")]
	public async Task<IActionResult> Register(RegisterRequest request)
	{
		var token = await mediator.Send(new RegisterCommand(request));
		return Ok(token);
	}

	[Authorize(Roles = "Admin")]
	[HttpPut("change-user-claims")]
	public async Task<IActionResult> ChangeUserClaims(ChangeUserClaimRequest request)
	{
		await mediator.Send(new ChangeUserClaimsCommand(request));
		return Ok("New account created.");
	}
}