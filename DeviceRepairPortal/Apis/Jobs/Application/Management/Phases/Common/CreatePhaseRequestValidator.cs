using FluentValidation;

namespace Application.Management.Phases.Common;

internal class CreatePhaseRequestValidator : AbstractValidator<CreatePhaseRequest>
{
    public CreatePhaseRequestValidator()
	{
		RuleFor(x => x.JobId).NotEmpty()
			.WithMessage("Must provide a JobId.");
	}
}