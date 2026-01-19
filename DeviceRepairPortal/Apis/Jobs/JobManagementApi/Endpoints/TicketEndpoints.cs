using Application.Management.Tikets;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobManagementApi.Endpoints;

public class TicketEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/tickets")
            .RequireAuthorization();

        group.MapPost("", CreateTicket)
            .WithName(nameof(CreateTicket));
    }

    public async Task<IResult> CreateTicket([FromServices] IMediator mediator, [FromBody] CreateTicketRequest request)
    {
        await mediator.Send(new CreateTicketCommand(request));
        return Results.Ok();
    }
}