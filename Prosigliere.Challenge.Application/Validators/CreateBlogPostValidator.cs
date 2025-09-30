using FluentValidation;

using Prosigliere.Challenge.Application.Commands;

namespace Prosigliere.Challenge.Application.Validators;

public class CreateBlogPostValidator : AbstractValidator<CreateBlogPost>
{
    public CreateBlogPostValidator()
    {
        RuleFor(x => x.Title)
            .NotNull()
            .NotEmpty()
            .MaximumLength(200);

        RuleFor(x => x.Content)
            .NotNull()
            .NotEmpty();
    }
}
