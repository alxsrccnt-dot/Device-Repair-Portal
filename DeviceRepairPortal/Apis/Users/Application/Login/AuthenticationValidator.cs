using FluentValidation;

namespace Application.Login;

public class AuthenticationValidator : AbstractValidator<AuthenticationRequest>
{
	public AuthenticationValidator()
	{
		RuleFor(x => x.Email)
			.NotNull()
			.MinimumLength(1)
			.WithMessage("Must provide a email.");

		RuleFor(x => x.Password)
			.MinimumLength(1)
			.WithMessage("Must provide a password.");
	}
}