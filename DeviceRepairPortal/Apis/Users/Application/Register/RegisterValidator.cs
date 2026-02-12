using FluentValidation;

namespace Application.Register;

public class RegisterValidator : AbstractValidator<RegisterRequest>
{
	public RegisterValidator()
	{
		RuleFor(x => x.UserName)
			.NotNull()
			.MinimumLength(1)
			.WithMessage("Must provide a username.");

		RuleFor(x => x.Email)
			.EmailAddress()
			.WithMessage("Must provide a valid email adress.");

		RuleFor(x => x.Password)
			.MinimumLength(1)
			.WithMessage("Must provide a password.");
	}
}