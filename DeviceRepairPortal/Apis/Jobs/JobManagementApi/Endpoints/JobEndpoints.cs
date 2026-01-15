using Application.Investigations;
using Application.Jobs;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobManagementApi.Endpoints;

public class JobEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/jobs")
            .RequireAuthorization("technicians.manage"); ;

        group.MapPost("", CreateJob)
            .WithName(nameof(CreateJob));
    }

    public async Task<IResult> CreateJob([FromServices] IMediator mediator, [FromBody] CreateJobRequest request)
    {
        await mediator.Send(new CreateJobCommand(request));
        return Results.Ok("Job created.");
    }
}