using MediatR;

namespace Application.Billings;

public record CreateBillingInformationCommand(CreateBillingInformationRequest Request) : IRequest;