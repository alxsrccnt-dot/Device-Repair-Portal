using FluentValidation;

namespace Application.Management.Investigations;

internal class CreateInvestigationRequestValidator : AbstractValidator<CreateInvestigationRequest>
{
    public CreateInvestigationRequestValidator()
	{
		RuleFor(x => x.JobId).NotEmpty()
			.WithMessage("Must provide a JobId.");

		RuleFor(x => x.Conclusion)
            .MinimumLength(1)
            .WithMessage("The conclusion must be not null.");
    }
}