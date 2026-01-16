using Application.Management.Phases.Common;
using MediatR;

namespace Application.Management.Phases.Repair;

public record CreateRepairPhaseCommand(CreatePhaseRequest Request) : IRequest;