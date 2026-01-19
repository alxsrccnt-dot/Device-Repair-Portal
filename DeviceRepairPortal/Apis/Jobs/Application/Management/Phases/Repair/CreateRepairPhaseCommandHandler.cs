using Application.Common.Exceptions;
using Application.Common.Services;
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

        var job = await jobReadRepository.GetByIdAsync(request.JobId, cancellationToken);
        if (job == null)
            throw new NotFoundException("The job can not be found.");

        var phase = new Phase(request.JobId, State.Repair, currentUser.Email!, currentUser.UserName!, DateTime.UtcNow);
        await phaseCreateRepository.CreateAsync(phase, cancellationToken);
    }
}