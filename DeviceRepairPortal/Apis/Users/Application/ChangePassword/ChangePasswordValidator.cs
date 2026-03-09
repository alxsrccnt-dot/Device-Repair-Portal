using FluentValidation;

namespace Application.ChangePassword;

public class ChangePasswordValidator : AbstractValidator<ChangePasswordRequest>
{
	public ChangePasswordValidator()
	{
		RuleFor(x => x.UserEmail)
			.NotEmpty().WithMessage("Email is required.")
			.EmailAddress().WithMessage("Email must be a valid email address.");

		RuleFor(x => x.OldPassword)
			.NotEmpty().WithMessage("Current password is required.");

		RuleFor(x => x.NewPassword)
			.NotEmpty().WithMessage("New password is required.")
			.MinimumLength(6).WithMessage("New password must be at least 6 characters long.")
			.Matches(@"[A-Z]").WithMessage("New password must contain at least one uppercase letter.")
			.Matches(@"[a-z]").WithMessage("New password must contain at least one lowercase letter.")
			.Matches(@"[0-9]").WithMessage("New password must contain at least one digit.");

		RuleFor(x => x.NewPassword)
			.NotEqual(x => x.OldPassword)
			.WithMessage("New password must be different from the current password.");
	}
}

