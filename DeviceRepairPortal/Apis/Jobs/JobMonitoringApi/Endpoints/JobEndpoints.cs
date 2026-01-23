using Application.Monitoring.Jobs;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobMonitoringApi.Endpoints;

public class JobEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var techniciansGroup = app.MapGroup("/api/jobs")
            .RequireAuthorization("technicians.read");

        techniciansGroup.MapGet("", GetTehnicianJobs)
            .WithName(nameof(GetTehnicianJobs));

        var group = app.MapGroup("/api/jobs")
            .RequireAuthorization();
        group.MapGet("details", GetJob)
            .WithName(nameof(GetJob));
    }

    public async Task<IResult> GetTehnicianJobs([FromServices] IMediator mediator,
        [AsParameters] GetTehnicianJobsQuery query)
        => Results.Ok(await mediator.Send(query));

    public async Task<IResult> GetJob([FromServices] IMediator mediator,
        [AsParameters] GetJobDetailsQuery query)
        => Results.Ok(await mediator.Send(query));
}