using FluentValidation;

namespace Application.Management.Phases.Common;

public class CreatePhaseValidator : AbstractValidator<CreatePhaseRequest>
{
    public CreatePhaseValidator()
	{
		RuleFor(x => x.JobId).NotEmpty()
			.WithMessage("Must provide a JobId.");
	}
}