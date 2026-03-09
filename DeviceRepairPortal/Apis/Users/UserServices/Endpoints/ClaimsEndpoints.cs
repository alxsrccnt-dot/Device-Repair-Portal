using Application.ChangeEmail;
using Application.ChangePassword;
using Application.ChangeUserRole;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UserServices.Infrastructure;

namespace UserServices.Endpoints;

public class ClaimsEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/claims")
            .RequireAuthorization();
		
        group.MapPost("change-email", ChangeEmail)
            .WithName(nameof(ChangeEmail))
            .WithSummary("Change user email.")
            .WithRequestValidation<ChangeEmailRequest>();

        group.MapPatch("change-password", ChangePassword)
            .WithName(nameof(ChangePassword))
            .WithSummary("Change user password.")
            .WithRequestValidation<ChangePasswordRequest>();

        var groupAdmin = app.MapGroup("/api/admin/claims")
            .RequireAuthorization("admins.manage");
        
        groupAdmin.MapPatch("change-role", ChangeUserRole)
            .WithName(nameof(ChangeUserRole))
            .WithSummary("Change user role.")
            .WithRequestValidation<ChangeRoleRequest>();
    }

    public async Task<IResult> ChangeEmail([FromServices] IMediator mediator, [FromBody] ChangeEmailRequest request)
    {
        await mediator.Send(new ChangeEmailCommand(request));
        return Results.Ok();
    }

    public async Task<IResult> ChangePassword([FromServices] IMediator mediator, [FromBody] ChangePasswordRequest request)
    {
        await mediator.Send(new ChangePasswordCommand(request));
        return Results.Ok();
    }

    public async Task<IResult> ChangeUserRole([FromServices] IMediator mediator, [FromBody] ChangeRoleRequest request)
    {
        await mediator.Send(new ChangeRoleCommand(request));
        return Results.Ok();
    }
}