using Application.Common.Exceptions;
using Application.Common.Services;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Data.Repositories.Commands;
using Infrastructure.Data.Repositories.Queries;
using MediatR;

namespace Application.Management.Phases.Return;

public class CreateReturnPhaseCommandHandler(ICurrentUser currentUser,
    ICreateRepository<Phase> phaseCreateRepository,
    IUpdateRepository<Job> jobUpdateRepository,
    IReadRepository<Job> jobReadRepository)
    : IRequestHandler<CreateReturnPhaseCommand>
{
    public async Task Handle(CreateReturnPhaseCommand command, CancellationToken cancellationToken)
    {
        var request = command.Request;

        var job = await jobReadRepository.GetByIdAsync(request.JobId, cancellationToken);
        if (job == null)
            throw new NotFoundException("The job can not be found.");

        job.EndDate = DateTime.UtcNow;
        await jobUpdateRepository.UpdateAsync(job, cancellationToken);

        var phase = new Phase(request.JobId, State.Return, currentUser.Email!, currentUser.UserName!, DateTime.UtcNow);
        await phaseCreateRepository.CreateAsync(phase, cancellationToken);
    }
}