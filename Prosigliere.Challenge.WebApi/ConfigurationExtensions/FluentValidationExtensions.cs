using FluentValidation;

using Prosigliere.Challenge.Application.Validators;

namespace Prosigliere.Challenge.WebApi.ConfigurationExtensions;

public static class FluentValidationExtensions
{
    public static void AddFluentValidation(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<CreateBlogPostValidator>();
    }
}