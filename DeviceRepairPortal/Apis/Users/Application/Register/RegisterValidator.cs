using FluentValidation;

namespace Application.Register;

public class RegisterValidator : AbstractValidator<RegisterRequest>
{
	public RegisterValidator()
	{
		RuleFor(x => x.UserName)
			.NotNull()
			.MinimumLength(1)
			.WithMessage("Must provide a email.");

		RuleFor(x => x.Email)
			.NotNull()
			.MinimumLength(1)
			.WithMessage("Must provide a email.");

		RuleFor(x => x.Password)
			.MinimumLength(1)
			.WithMessage("Must provide a password.");
	}
}