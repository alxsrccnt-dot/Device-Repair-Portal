using Application.ChangeUserClaim;
using Application.SeedDb;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace UserServices.Controllers;

[ApiController]
[Route("api/account")]
public class AccountController(IMediator mediator) : Controller
{
    [AllowAnonymous]
    [HttpPut("change-user-claims")]
    public async Task<IActionResult> ChangeUserClaims(ChangeUserClaimRequest request)
    {
        await mediator.Send(new ChangeUserClaimsCommand(request));
        return Ok("New account created.");
    }

    [AllowAnonymous]
    [HttpPost("seed-db")]
    public async Task<IActionResult> SeedDb()
    {
        await mediator.Send(new SeedDbCommand());
        return Ok("FakeUsers was created.");
    }
}