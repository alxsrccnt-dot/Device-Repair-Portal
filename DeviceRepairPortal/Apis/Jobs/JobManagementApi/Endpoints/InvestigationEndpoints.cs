using Application.Management.Investigations;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobManagementApi.Endpoints;

public class InvestigationEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/investigations")
            .RequireAuthorization("technicians.manage"); ;

        group.MapPost("", CreateInvestigation)
            .WithName(nameof(CreateInvestigation));
    }

    public async Task<IResult> CreateInvestigation([FromServices] IMediator mediator, [FromBody] CreateInvestigationRequest request)
    {
        await mediator.Send(new CreateInvestigationCommand(request));
        return Results.Ok("Investigation was added.");
    }
}