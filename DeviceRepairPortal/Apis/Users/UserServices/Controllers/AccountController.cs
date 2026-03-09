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
    [HttpPost("seed-db")]
    public async Task<IActionResult> SeedDb()
    {
        await mediator.Send(new SeedDbCommand());
        return Ok("FakeUsers was created.");
    }
}