using Prosigliere.Challenge.Application.Commands;
using Prosigliere.Challenge.WebApi.ConfigurationExtensions;

namespace Prosigliere.Challenge.WebApi.ConfigurationExtensions;

public static class MediatRExtensions
{
    public static void AddMediatR(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateBlogPost>());
    }
}