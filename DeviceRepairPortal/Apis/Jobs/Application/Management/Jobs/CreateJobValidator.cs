using FluentValidation;

namespace Application.Management.Jobs;

public class CreateJobValidator : AbstractValidator<CreateJobRequest>
{
    public CreateJobValidator()
	{
		RuleFor(x => x.TicketId).NotEmpty()
			.WithMessage("Must provide a TicketId.");
	}
}