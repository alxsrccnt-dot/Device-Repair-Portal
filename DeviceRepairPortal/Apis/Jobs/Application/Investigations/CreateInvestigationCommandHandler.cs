using Application.Common.Exceptions;
using Application.Common.Services;
using Domain.Entities;
using Domain.Enums;
using Infrastructure.Data.Repositories.Commands;
using Infrastructure.Data.Repositories.Queries;
using MediatR;

namespace Application.Investigations;

public class CreateInvestigationCommandHandler(ICurrentUser currentUser,
    ICreateRepository<Investigation> investigationCreateRepository, ICreateRepository<Phase> phaseCreateRepository,
    IReadRepository<Job> jobReadRepository,
    IReadIssuesRepositories readIssuesRepositories)
    : IRequestHandler<CreateInvestigationCommand>
{
    public async Task Handle(CreateInvestigationCommand command, CancellationToken cancellationToken)
    {
        var request = command.Request;

        var job = await jobReadRepository.GetByIdAsync(request.JobId, cancellationToken);
        if (job == null)
            throw new NotFoundException("The job can not be found.");

        var issues = await readIssuesRepositories.GetIssuesByIds(request.IssuesIds, cancellationToken);
        var investigation = new Investigation(request.JobId, request.Conclusion, request.Description, issues,
            currentUser.Email!, currentUser.UserName!, DateTime.UtcNow);

        await investigationCreateRepository.CreateAsync(investigation, cancellationToken);

        var phase = new Phase(request.JobId, State.Investigation, currentUser.Email!, currentUser.UserName!, investigation.CreateAt);
        await phaseCreateRepository.CreateAsync(phase, cancellationToken);
    }
}