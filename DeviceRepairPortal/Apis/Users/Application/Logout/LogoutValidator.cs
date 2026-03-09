using FluentValidation;

namespace Application.Logout;

public class LogoutValidator : AbstractValidator<LogoutRequest>
{
    public LogoutValidator()
    {
        RuleFor(x => x.Token)
            .MinimumLength(1)
            .WithMessage("Must provide a valid refresh token.");
    }
}