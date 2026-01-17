using Application.Monitoring.Jobs;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobMonitoringApi.Endpoints;

public class JobEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/jobs")
            .RequireAuthorization("technicians.read");

        group.MapGet("", GetTehnicianJobs)
            .WithName(nameof(GetTehnicianJobs));
    }

    public async Task<IResult> GetTehnicianJobs([FromServices] IMediator mediator,
        [AsParameters] GetTehnicianJobsQuery query)
        => Results.Ok(await mediator.Send(query));
}