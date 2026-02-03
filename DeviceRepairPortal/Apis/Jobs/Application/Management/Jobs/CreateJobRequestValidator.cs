using Domain.Entities;
using FluentValidation;
using Infrastructure.Data.Repositories.Queries;

namespace Application.Management.Jobs;

internal class CreateJobRequestValidator : AbstractValidator<CreateJobRequest>
{
    public CreateJobRequestValidator(IReadRepository<Ticket> readRepository)
    {
        RuleFor(x => x.TicketId).MustAsync(async (id, cancellation) =>
        {
            var exists = await readRepository.GetByIdAsync(id, cancellation);
            return exists is null;
        }).WithMessage("Ticket must exist in db.");
    }
}