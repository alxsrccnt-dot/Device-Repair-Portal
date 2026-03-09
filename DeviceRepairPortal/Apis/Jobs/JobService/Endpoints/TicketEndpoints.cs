using Application.Management.Tikets;
using Application.Monitoring.Tickets;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using JobService.Infrastructure;

namespace JobService.Endpoints;

public class TicketEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/tickets")
            .RequireAuthorization();

        group.MapPost("", CreateTicket)
            .WithName(nameof(CreateTicket))
			.WithSummary("Create a new tickets .")
			.WithRequestValidation<CreateTicketRequest>();

		group.MapGet("", GetUserTickets)
            .WithName(nameof(GetUserTickets));

        var technicianGroup = app.MapGroup("/api/technician-tickets")
            .RequireAuthorization("technicians.read");

        technicianGroup.MapGet("", GetTickets)
            .WithName(nameof(GetTickets));
    }

    public async Task<IResult> CreateTicket([FromServices] IMediator mediator,
        [FromBody] CreateTicketRequest request)
    {
        await mediator.Send(new CreateTicketCommand(request));
        return Results.Created();
    }
         
    public async Task<IResult> GetUserTickets([FromServices] IMediator mediator,
        [AsParameters] GetUserTicketsQuery query)
        => Results.Ok(await mediator.Send(query));

    public async Task<IResult> GetTickets([FromServices] IMediator mediator,
        [AsParameters] GetTicketsQuery query)
        => Results.Ok(await mediator.Send(query));
}