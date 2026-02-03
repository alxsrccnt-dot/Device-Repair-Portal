using Domain.Entities;
using FluentValidation;
using Infrastructure.Data.Repositories.Queries;

namespace Application.Management.Comments;

internal class CreateCommentRequestValidator : AbstractValidator<CreateCommentRequest>
{
    public CreateCommentRequestValidator(IReadRepository<Job> jobReadRepository)
    {
        RuleFor(x => x.JobId).MustAsync(async (id, cancellation) =>
        {
            var exists = await jobReadRepository.GetByIdAsync(id, cancellation);
            return exists is not null;
        }).WithMessage("Job must exist in db.");

        RuleFor(x => x.Comment)
            .MinimumLength(1)
            .WithMessage("The content must be not null.");
    }
}