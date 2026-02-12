using FluentValidation;

namespace Application.Management.Comments;

public class CreateCommentValidator : AbstractValidator<CreateCommentRequest>
{
    public CreateCommentValidator()
    {
        RuleFor(x => x.JobId).NotEmpty()
			.WithMessage("Must provide a JobId.");

		RuleFor(x => x.Comment)
            .MinimumLength(1)
            .WithMessage("The content must be not null.");
    }
}