using Application.Common.Exceptions;
using Application.Common.Services;
using Domain.Entities;
using Infrastructure.Data.Repositories.Commands;
using Infrastructure.Data.Repositories.Queries;
using MediatR;

namespace Application.Jobs;

public class CreateJobCommandHandler(ICurrentUser currentUser, ICreateRepository<Job> createRepository, IReadRepository<Ticket> readRepository) : IRequestHandler<CreateJobCommand>
{
    public async Task Handle(CreateJobCommand command, CancellationToken cancellationToken)
    {
        var request = command.Request;

        var ticket = await readRepository.GetByIdAsync(request.TicketId, cancellationToken);
        if (ticket == null)
            throw new NotFoundException("The ticket can not be found.");

        Job newJob = string.IsNullOrWhiteSpace(request.Comment)
            ? new Job(request.TicketId, currentUser.Email!, currentUser.UserName!, DateTime.UtcNow)
            : new Job(request.TicketId, request.Comment, currentUser.Email!, currentUser.UserName!, DateTime.UtcNow);

        await createRepository.CreateAsync(newJob, cancellationToken);
    }
}