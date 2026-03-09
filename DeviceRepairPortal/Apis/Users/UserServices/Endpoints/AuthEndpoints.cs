using Application.Login;
using Application.LoginWithRefreshToken;
using Application.Logout;
using Application.Register;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserServices.Infrastructure;

namespace UserServices.Endpoints;

public class AuthEndpoints : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		var group = app.MapGroup("/api/auth")
			.AllowAnonymous();
		
		group.MapPost("register", Register)
			.WithName(nameof(Register))
			.WithSummary("Create an account to receive a token.")
			.WithRequestValidation<RegisterRequest>();

		group.MapPost("login", Login)
			.WithName(nameof(Login))
			.WithSummary("Login to receive a token.")
			.WithRequestValidation<AuthenticationRequest>();

		group.MapPatch("login", LoginWithRefreshToken)
			.WithName(nameof(LoginWithRefreshToken))
			.WithSummary("Login to receive a token.")
			.WithRequestValidation<AuthenticationWithRefreshTokenRequest>();
		
		var authGroup = app.MapGroup("/api/auth")
			.RequireAuthorization();
		
		authGroup.MapDelete("logout", Logout)
			.WithName(nameof(Logout))
			.WithSummary("Logout by revoking the refresh token.")
			.WithRequestValidation<LogoutRequest>();
	}

	public async Task<IResult> Login([FromServices] IMediator mediator, [FromBody] AuthenticationRequest request)
	{
		var token = await mediator.Send(new LoginCommand(request));
		return Results.Ok(token);
	}

	public async Task<IResult> LoginWithRefreshToken([FromServices] IMediator mediator, [FromBody] AuthenticationWithRefreshTokenRequest request)
	{
		var token = await mediator.Send(new LoginWithRefreshTokenCommand(request));
		return Results.Ok(token);
	}

	public async Task<IResult> Register([FromServices] IMediator mediator, [FromBody] RegisterRequest request)
	{
		var token = await mediator.Send(new RegisterCommand(request));
		return Results.Ok(token);
	}

	public async Task<IResult> Logout([FromServices] IMediator mediator, [FromBody] LogoutRequest request)
	{
		await mediator.Send(new LogoutCommand(request));
		return Results.Ok();
	}
}