using FluentValidation;

namespace Application.Management.Investigations;

public class CreateInvestigationValidator : AbstractValidator<CreateInvestigationRequest>
{
    public CreateInvestigationValidator()
	{
		RuleFor(x => x.JobId).NotEmpty()
			.WithMessage("Must provide a JobId.");

		RuleFor(x => x.Conclusion)
            .MinimumLength(1)
            .WithMessage("The conclusion must be not null.");
    }
}