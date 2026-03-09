using FluentValidation;

namespace Application.ChangeEmail;

public class ChangeEmailValidator : AbstractValidator<ChangeEmailRequest>
{
	public ChangeEmailValidator()
	{
		RuleFor(x => x.CurrentEmail)
			.EmailAddress().WithMessage("Current Email must be a valid email address.")
			.NotEmpty().WithMessage("Current Email is required.");

		RuleFor(x => x.NewEmail)
			.NotEmpty().WithMessage("New Email is required.")
			.EmailAddress().WithMessage("Email must be a valid email address.")
			.MaximumLength(256).WithMessage("Email must not exceed 256 characters.");

		RuleFor(x => x.Password)
			.NotEmpty().WithMessage("Password is required.")
			.MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
	}
}

