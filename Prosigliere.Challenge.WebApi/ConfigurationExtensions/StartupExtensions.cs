using MediatR;

using Prosigliere.Challenge.Application.Validators;

namespace Prosigliere.Challenge.WebApi.ConfigurationExtensions;

public static class StartupExtensions
{
    public static void AddCustomServices(this IServiceCollection services)
    {
        services.AddAutoMapper();
        services.AddFluentValidation();
        services.AddMediatR();
        services.AddRepositories();
        services.AddUnitOfWork();
        services.AddServices();
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
    }
}
