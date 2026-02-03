using Domain.Entities;
using FluentValidation;
using Infrastructure.Data.Repositories.Queries;

namespace Application.Management.Billings;

internal class CreateBillingInformationRequestValidator : AbstractValidator<CreateBillingInformationRequest>
{
    public CreateBillingInformationRequestValidator(IReadRepository<Job> jobReadRepository)
    {
        RuleFor(x => x.JobId).MustAsync(async (id, cancellation) =>
        {
            var exists = await jobReadRepository.GetByIdAsync(id, cancellation);
            return exists is not null;
        }).WithMessage("Job must exist in db.");

        RuleFor(x => x.Amount)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Amount must be a positive number.");
    }
}