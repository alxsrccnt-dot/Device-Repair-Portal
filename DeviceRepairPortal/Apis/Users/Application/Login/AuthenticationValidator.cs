using FluentValidation;

namespace Application.Login;

public class AuthenticationValidator : AbstractValidator<AuthenticationRequest>
{
	public AuthenticationValidator()
	{
		RuleFor(x => x.Email)
			.EmailAddress()
			.WithMessage("Must provide a valid email adress.");

		RuleFor(x => x.Password)
			.MinimumLength(1)
			.WithMessage("Must provide a password.");
	}
}