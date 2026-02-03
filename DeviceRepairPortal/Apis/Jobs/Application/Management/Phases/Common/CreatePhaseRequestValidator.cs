using Domain.Entities;
using FluentValidation;
using Infrastructure.Data.Repositories.Queries;

namespace Application.Management.Phases.Common;

internal class CreatePhaseRequestValidator : AbstractValidator<CreatePhaseRequest>
{
    public CreatePhaseRequestValidator(IReadRepository<Job> jobReadRepository)
    {
        RuleFor(x => x.JobId).MustAsync(async (id, cancellation) =>
        {
            var exists = await jobReadRepository.GetByIdAsync(id, cancellation);
            return exists is not null;
        }).WithMessage("Job must exist in db.");
    }
}