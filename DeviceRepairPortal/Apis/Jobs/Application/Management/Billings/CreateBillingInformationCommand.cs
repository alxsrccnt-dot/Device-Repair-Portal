using MediatR;

namespace Application.Management.Billings;

public record CreateBillingInformationCommand(CreateBillingInformationRequest Request) : IRequest;