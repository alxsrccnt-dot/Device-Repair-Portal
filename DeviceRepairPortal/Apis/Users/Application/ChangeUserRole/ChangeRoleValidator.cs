using Application.ChangePassword;
using Application.Shared.Identity;
using FluentValidation;

namespace Application.ChangeUserRole;

public class ChangeRoleValidator : AbstractValidator<ChangeRoleRequest>
{
	public ChangeRoleValidator()
	{
		RuleFor(x => x.UserEmail)
			.NotEmpty().WithMessage("Email is required.")
			.EmailAddress().WithMessage("Email must be a valid email address.");

		RuleFor(x => x.NewClaim)
			.Must(c => c == AppRoles.Admin || c == AppRoles.Technician || c == AppRoles.User)
			.NotEmpty()
			.WithMessage("Current password is required.");
	}
}

