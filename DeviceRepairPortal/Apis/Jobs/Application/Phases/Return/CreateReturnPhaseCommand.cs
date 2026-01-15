using Application.Phases.Common;
using MediatR;

namespace Application.Phases.Return;

public record CreateReturnPhaseCommand(CreatePhaseRequest Request) : IRequest;