using FluentValidation;

namespace Application.Management.Issues;

public class CreateIssueValidator : AbstractValidator<CreateIssueRequest>
{
    public CreateIssueValidator()
    {
        RuleFor(x => x.DevicePiece)
            .MinimumLength(1)
            .WithMessage("The device piece must be not null.");

        RuleFor(x => x.Description)
            .MinimumLength(1)
            .WithMessage("The description must be not null.");

        RuleFor(x => x.Price)
            .GreaterThan(1)
            .WithMessage("The price must have a positive value.");
    }
}