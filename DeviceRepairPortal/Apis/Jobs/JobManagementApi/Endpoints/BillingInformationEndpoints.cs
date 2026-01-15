using Application.Billings;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobManagementApi.Endpoints;

public class BillingInformationEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/billings")
            .RequireAuthorization("technicians.manage"); ;

        group.MapPost("", CreateBillingInformation)
            .WithName(nameof(CreateBillingInformation));
    }

    public async Task<IResult> CreateBillingInformation([FromServices] IMediator mediator, [FromBody] CreateBillingInformationRequest request)
    {
        await mediator.Send(new CreateBillingInformationCommand(request));
        return Results.Ok("Billing was added.");
    }
}