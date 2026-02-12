using Application.Management.Billings;
using Carter;
using JobService.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace JobService.Endpoints;

public class BillingInformationEndpoints : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/billings")
            .RequireAuthorization("technicians.manage");

        group.MapPost("", CreateBillingInformation)
            .WithName(nameof(CreateBillingInformation))
			.WithSummary("Add billing to current job.")
			.WithRequestValidation<CreateBillingInformationRequest>();
	}

    public async Task<IResult> CreateBillingInformation([FromServices] IMediator mediator, [FromBody] CreateBillingInformationRequest request)
    {
        await mediator.Send(new CreateBillingInformationCommand(request));
        return Results.Ok();
    }
}