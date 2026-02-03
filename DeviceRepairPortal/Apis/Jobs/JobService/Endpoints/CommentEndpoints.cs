using Application.Management.Comments;
using Application.Management.Common;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobService.Endpoints;

public class CommentEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/comments")
            .RequireAuthorization(); ;

        group.MapPost("", CreateComment)
            .WithName(nameof(CreateComment))
            .AddEndpointFilter<ValidationFilter<CreateCommentRequest>>();
    }

    public async Task<IResult> CreateComment([FromServices] IMediator mediator, [FromBody] CreateCommentRequest request)
    {
        await mediator.Send(new CreateCommentCommand(request));
        return Results.Ok();
    }
}