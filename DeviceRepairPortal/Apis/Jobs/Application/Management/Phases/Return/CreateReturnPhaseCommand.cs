using Application.Management.Phases.Common;
using MediatR;

namespace Application.Management.Phases.Return;

public record CreateReturnPhaseCommand(CreatePhaseRequest Request) : IRequest;