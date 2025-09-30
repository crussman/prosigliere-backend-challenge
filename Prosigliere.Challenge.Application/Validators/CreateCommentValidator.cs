using FluentValidation;

using Prosigliere.Challenge.Application.Commands;

namespace Prosigliere.Challenge.Application.Validators;

public class CreateCommentValidator : AbstractValidator<CreateComment>
{
    public CreateCommentValidator()
    {
        RuleFor(x => x.BlogPostId)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.Content)
            .NotNull()
            .NotEmpty()
            .MaximumLength(1000);
    }
}
