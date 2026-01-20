using Application.Common.Exceptions;
using Application.Common.Services;
using Domain.Entities;
using Infrastructure.Data.Repositories.Commands;
using Infrastructure.Data.Repositories.Queries;
using MediatR;

namespace Application.Management.Comments;

internal class CreateCommentHandler(ICurrentUser currentUser, ICreateRepository<Comment> commentCreateRepository, IReadRepository<Job> jobReadRepository) : IRequestHandler<CreateCommentCommand>
{
    public async Task Handle(CreateCommentCommand command, CancellationToken cancellationToken)
    {
        var request = command.Request;

        var job = await jobReadRepository.GetByIdAsync(request.JobId, cancellationToken);
        if (job == null)
            throw new NotFoundException("The job can not be found.");

        var comment = new Comment(request.JobId, request.Comment, currentUser.Email!, currentUser.UserName!, DateTime.UtcNow);

        await commentCreateRepository.CreateAsync(comment, cancellationToken);
    }
}