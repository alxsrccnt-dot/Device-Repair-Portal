using Application.Common.Exceptions;
using Domain.Entities;
using Infrastructure.Data.Repositories.Commands;
using Infrastructure.Data.Repositories.Queries;
using MediatR;

namespace Application.Management.Issues;

public class CreateIssueCommandHandler(IReadIssuesRepositories readIssuesRepositories, ICreateRepository<Issue> createRepository)
    : IRequestHandler<CreateIssueCommand>
{
    public async Task Handle(CreateIssueCommand command, CancellationToken cancellationToken)
    {
        var request = command.Request;

        var existingIssue = await readIssuesRepositories.GetByDevicePieceAsync(request.DevicePiece);
        if (existingIssue is not null)
            throw new ValidationException("The issue already exist.");

        var issue = new Issue(request.DevicePiece, request.Description, request.Price);
        await createRepository.CreateAsync(issue, cancellationToken);
    }
}
