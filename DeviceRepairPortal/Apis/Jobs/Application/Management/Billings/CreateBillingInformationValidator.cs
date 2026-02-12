using FluentValidation;

namespace Application.Management.Billings;

public class CreateBillingInformationValidator : AbstractValidator<CreateBillingInformationRequest>
{
    public CreateBillingInformationValidator()
    {
		RuleFor(x => x.JobId).NotEmpty()
			.WithMessage("Must provide a JobId.");

		RuleFor(x => x.Amount)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Amount must be a positive number.");
    }
}