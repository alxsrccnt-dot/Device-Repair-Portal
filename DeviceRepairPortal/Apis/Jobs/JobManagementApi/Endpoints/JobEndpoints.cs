using Application.Management.Jobs;
using Application.Management.Phases.Common;
using Application.Management.Phases.Repair;
using Application.Management.Phases.Return;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobManagementApi.Endpoints;

public class JobEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/jobs")
            .RequireAuthorization("technicians.manage");

        group.MapPost("", CreateJob)
            .WithName(nameof(CreateJob));

        group.MapPost("/phases/repair", CreateRepairPhase)
            .WithName(nameof(CreateRepairPhase));

        group.MapPost("/phases/return", CreateReturnPhase)
            .WithName(nameof(CreateReturnPhase));
    }

    public async Task<IResult> CreateJob([FromServices] IMediator mediator, [FromBody] CreateJobRequest request)
    {
        await mediator.Send(new CreateJobCommand(request));
        return Results.Ok();
    }

    public async Task<IResult> CreateRepairPhase([FromServices] IMediator mediator, [FromBody] CreatePhaseRequest request)
    {
        await mediator.Send(new CreateRepairPhaseCommand(request));
        return Results.Ok();
    }

    public async Task<IResult> CreateReturnPhase([FromServices] IMediator mediator, [FromBody] CreatePhaseRequest request)
    {
        await mediator.Send(new CreateReturnPhaseCommand(request));
        return Results.Ok();
    }
}