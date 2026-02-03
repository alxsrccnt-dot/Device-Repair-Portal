using Domain.Entities;
using FluentValidation;
using Infrastructure.Data.Repositories.Queries;

namespace Application.Management.Investigations;

internal class CreateInvestigationRequestValidator : AbstractValidator<CreateInvestigationRequest>
{
    public CreateInvestigationRequestValidator(IReadRepository<Job> jobReadRepository)
    {
        RuleFor(x => x.JobId).MustAsync(async (id, cancellation) =>
        {
            var exists = await jobReadRepository.GetByIdAsync(id, cancellation);
            return exists is not null;
        }).WithMessage("Job must exist in db.");

        RuleFor(x => x.Conclusion)
            .MinimumLength(1)
            .WithMessage("The conclusion must be not null.");
    }
}