using Application.Management.Issues;
using Application.Monitoring.Issues;
using Carter;
using JobService.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobService.Endpoints;

public class IssueEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var adminGroup = app.MapGroup("/api/admin/issues")
            .RequireAuthorization("admins.manage"); ;

        adminGroup.MapPost("", CreateIssue)
            .WithName(nameof(CreateIssue))
			.WithRequestValidation<CreateIssueRequest>();

		var group = app.MapGroup("/api/issues")
            .AllowAnonymous();

        group.MapGet("", GetIssues)
            .WithName(nameof(GetIssues));
    }

    public async Task<IResult> CreateIssue([FromServices] IMediator mediator, [FromBody] CreateIssueRequest request)
    {
        await mediator.Send(new CreateIssueCommand(request));
        return Results.Ok();
    }

    public async Task<IResult> GetIssues([FromServices] IMediator mediator,
        [AsParameters] GetIssueQuery query)
        => Results.Ok(await mediator.Send(new GetIssueQuery()));
}