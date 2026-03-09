using FluentValidation;

namespace Application.Management.Tikets;

public class CreateTicketValidator : AbstractValidator<CreateTicketRequest>
{
    public CreateTicketValidator()
    {
        RuleFor(x => x.Description)
			.NotNull()
			.MinimumLength(1)
            .WithMessage("Must provide a description.");

        RuleFor(x => x.Model)
			.NotNull()
			.MinimumLength(1)
            .WithMessage("Must provide a model.");

        RuleFor(x => x.Brand)
			.NotNull()
			.MinimumLength(1)
            .WithMessage("Must provide a brand.");

        RuleFor(x => x.SerialNumber)
			.NotNull()
			.MinimumLength(1)
            .WithMessage("Must provide a serial number.");
    }
}