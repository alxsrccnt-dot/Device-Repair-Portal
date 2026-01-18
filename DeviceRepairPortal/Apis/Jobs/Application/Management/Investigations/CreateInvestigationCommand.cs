using MediatR;

namespace Application.Management.Investigations;

public record CreateInvestigationCommand(CreateInvestigationRequest Request) : IRequest;