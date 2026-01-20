using Application.Management.Comments;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobManagementApi.Endpoints;

public class CommentEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/comments")
            .RequireAuthorization(); ;

        group.MapPost("", CreateComment)
            .WithName(nameof(CreateComment));
    }

    public async Task<IResult> CreateComment([FromServices] IMediator mediator, [FromBody] CreateCommentRequest request)
    {
        await mediator.Send(new CreateCommentCommand(request));
        return Results.Ok();
    }
}