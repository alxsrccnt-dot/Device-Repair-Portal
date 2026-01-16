using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobMonitoringApi.Endpoints;

public class IssueEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var adminGroup = app.MapGroup("/api/issues")
            .AllowAnonymous();

        adminGroup.MapGet("", GetIssues)
            .WithName(nameof(GetIssues));
    }

    public async Task<IResult> GetIssues([FromServices] IMediator mediator)
        => Results.Ok(await mediator.Send(new GetIssueQuery()));
}