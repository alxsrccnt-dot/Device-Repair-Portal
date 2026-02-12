using Application.Management.Jobs;
using Application.Management.Phases.Common;
using Application.Management.Phases.Repair;
using Application.Management.Phases.Return;
using Application.Monitoring.Jobs;
using Carter;
using JobService.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobService.Endpoints;

public class JobEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var techniciansGroup = app.MapGroup("/api/jobs")
            .RequireAuthorization("technicians.manage");

        techniciansGroup.MapPost("", CreateJob)
            .WithName(nameof(CreateJob))
			.WithRequestValidation<CreateJobRequest>();

        techniciansGroup.MapPost("/repair", CreateRepairPhase)
            .WithName(nameof(CreateRepairPhase))
			.WithRequestValidation<CreatePhaseRequest>();

        techniciansGroup.MapPost("/return", CreateReturnPhase)
            .WithName(nameof(CreateReturnPhase))
			.WithRequestValidation<CreatePhaseRequest>();

        techniciansGroup.MapGet("", GetTehnicianJobs)
            .WithName(nameof(GetTehnicianJobs));

        var group = app.MapGroup("/api/jobs")
            .RequireAuthorization();

        group.MapGet("{id:guid}", GetJob)
            .WithName(nameof(GetJob));
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

    public async Task<IResult> GetTehnicianJobs([FromServices] IMediator mediator,
        [AsParameters] GetJobsQuery query)
        => Results.Ok(await mediator.Send(query));

    public async Task<IResult> GetJob([FromServices] IMediator mediator,
        [AsParameters] Guid id)
        => Results.Ok(await mediator.Send(new GetJobDetailsQuery(id)));
}