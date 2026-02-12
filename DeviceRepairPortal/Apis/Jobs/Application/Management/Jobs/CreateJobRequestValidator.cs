using FluentValidation;

namespace Application.Management.Jobs;

internal class CreateJobRequestValidator : AbstractValidator<CreateJobRequest>
{
    public CreateJobRequestValidator()
	{
		RuleFor(x => x.TicketId).NotEmpty()
			.WithMessage("Must provide a TicketId.");
	}
}