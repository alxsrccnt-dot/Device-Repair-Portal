using Application.Exceptions;
using Application.Services;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Data.Repositories.Commands;
using Infrastructure.Data.Repositories.Queries;
using MediatR;

namespace Application.Management.Phases.Repair;

public class CreateRepairPhaseCommandHandler(ICurrentUser currentUser,
    ICreateRepository<Phase> phaseCreateRepository,
    IReadRepository<Job> jobReadRepository)
    : IRequestHandler<CreateRepairPhaseCommand>
{
    public async Task Handle(CreateRepairPhaseCommand command, CancellationToken cancellationToken)
    {
        var request = command.Request;

        _ = await jobReadRepository.GetByIdAsync(request.JobId, cancellationToken) ?? throw new NotFoundException("The job can not be found.");

        var phase = new Phase(request.JobId, State.Repair, currentUser.Email!, currentUser.UserName!, DateTime.UtcNow);
        await phaseCreateRepository.CreateAsync(phase, cancellationToken);
    }
}