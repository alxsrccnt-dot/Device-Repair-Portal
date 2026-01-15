using Application.Phases.Common;
using MediatR;

namespace Application.Phases.Repair;

public record CreateRepairPhaseCommand(CreatePhaseRequest Request) : IRequest;