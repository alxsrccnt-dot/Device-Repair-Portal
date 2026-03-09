using Application.Management.Issues;
using Carter;
using JobManagementApi.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobManagementApi.Endpoints;

public class IssueEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var adminGroup = app.MapGroup("/api/admin/issues")
            .RequireAuthorization("admins.manage"); ;

        adminGroup.MapPost("", CreateIssue)
            .WithName(nameof(CreateIssue))
            .WithRequestValidation<CreateIssueRequest>();
    }

    public async Task<IResult> CreateIssue([FromServices] IMediator mediator, [FromBody] CreateIssueRequest request)
    {
        await mediator.Send(new CreateIssueCommand(request));
        return Results.Ok();
    }
}