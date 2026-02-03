using Application.Management.Tikets;
using FluentValidation;

namespace Application.Management.Tiket;

internal class CreateTicketRequestValidator : AbstractValidator<CreateTicketRequest>
{
    public CreateTicketRequestValidator()
    {
        RuleFor(x => x.Description)
            .MinimumLength(1)
            .WithMessage("Must provide a description.");

        RuleFor(x => x.Model)
            .MinimumLength(1)
            .WithMessage("Must provide a model.");

        RuleFor(x => x.Brand)
            .MinimumLength(1)
            .WithMessage("Must provide a brand.");
        RuleFor(x => x.SerialNumber)

            .MinimumLength(1)
            .WithMessage("Must provide a serial number.");
    }
}