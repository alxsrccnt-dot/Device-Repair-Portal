using FluentValidation;

namespace Application.LoginWithRefreshToken;

public class AuthenticationWithRefreshTokenValidator : AbstractValidator<AuthenticationWithRefreshTokenRequest>
{
	public AuthenticationWithRefreshTokenValidator()
	{
		RuleFor(x => x.RefreshToken)
			.MinimumLength(1)
			.WithMessage("Must provide a valid refresh token.");
	}
} 