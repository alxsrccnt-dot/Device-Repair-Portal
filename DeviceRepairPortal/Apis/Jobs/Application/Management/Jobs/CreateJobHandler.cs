using Application.Exceptions;
using Application.Services;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Data.Repositories.Commands;
using Infrastructure.Data.Repositories.Queries;
using MediatR;

namespace Application.Management.Jobs;

public class CreateJobHandler(ICurrentUser currentUser,
    ICreateRepository<Job> jobCreateRepository, ICreateRepository<Phase> phaseCreateRepository,
    IReadRepository<Ticket> readRepository) : IRequestHandler<CreateJobCommand>
{
    public async Task Handle(CreateJobCommand command, CancellationToken cancellationToken)
    {
        var request = command.Request;

        _ = await readRepository.GetByIdAsync(request.TicketId, cancellationToken) ?? throw new NotFoundException("The ticket can not be found.");

        var newJob = new Job(request.TicketId, currentUser.Email!, currentUser.UserName!, DateTime.UtcNow);

        await jobCreateRepository.CreateAsync(newJob, cancellationToken);

        var phase = new Phase(newJob.Id, State.Reception ,currentUser.Email!, currentUser.UserName!, newJob.CreateAt);
        await phaseCreateRepository.CreateAsync(phase, cancellationToken);
    }
}