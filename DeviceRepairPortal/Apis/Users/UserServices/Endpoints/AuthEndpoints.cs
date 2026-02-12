using Application.Login;
using Application.Register;
using Carter;
using FluentValidation;
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

		group.MapPost("login", Login)
			.WithName(nameof(Login))
			.WithSummary("Login to receive a token.")
			.WithRequestValidation<AuthenticationRequest>();

		group.MapPost("register", Register)
			.WithName(nameof(Register))
			.WithSummary("Create an account to receive a token.")
			.WithRequestValidation<RegisterRequest>();
	}

	public async Task<IResult> Login([FromServices] IMediator mediator, [FromBody] AuthenticationRequest request)
	{
		var token = await mediator.Send(new LoginCommand(request));
		return Results.Ok(token);
	}

	public async Task<IResult> Register([FromServices] IMediator mediator, [FromBody] RegisterRequest request)
	{
		var token = await mediator.Send(new RegisterCommand(request));
		return Results.Ok(token);
	}
}