using MediatR;

namespace Application.Investigations;

public record CreateInvestigationCommand(CreateInvestigationRequest Request) : IRequest;