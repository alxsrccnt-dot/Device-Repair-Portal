using Application.Management.Billings;
using Application.Management.Common;
using Carter;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobService.Endpoints;

public class BillingInformationEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/billings")
            .RequireAuthorization("technicians.manage"); ;

        group.MapPost("", CreateBillingInformation)
            .WithName(nameof(CreateBillingInformation))
            .AddEndpointFilter<ValidationFilter<CreateBillingInformationRequest>>();
    }

    public async Task<IResult> CreateBillingInformation([FromServices] IMediator mediator, [FromBody] CreateBillingInformationRequest request)
    {
        await mediator.Send(new CreateBillingInformationCommand(request));
        return Results.Ok();
    }
}