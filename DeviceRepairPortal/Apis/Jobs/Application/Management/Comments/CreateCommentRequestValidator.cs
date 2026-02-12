using FluentValidation;

namespace Application.Management.Comments;

internal class CreateCommentRequestValidator : AbstractValidator<CreateCommentRequest>
{
    public CreateCommentRequestValidator()
    {
        RuleFor(x => x.JobId).NotEmpty()
			.WithMessage("Must provide a JobId.");

		RuleFor(x => x.Comment)
            .MinimumLength(1)
            .WithMessage("The content must be not null.");
    }
}