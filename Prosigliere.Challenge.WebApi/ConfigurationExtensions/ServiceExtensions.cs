using Prosigliere.Challenge.Domain.Services;
using Prosigliere.Challenge.Infrastructure.Services;

namespace Prosigliere.Challenge.WebApi.ConfigurationExtensions;

public static class ServiceExtensions
{
    public static void AddServices(this IServiceCollection services)
    {
        var serviceInterfaceType = typeof(IBlogPostService).Assembly;
        var assembly = typeof(BlogPostService).Assembly;

        var implementations = assembly.GetTypes()
            .Where(t => t.Name.EndsWith("Service") && !t.IsInterface && !t.IsAbstract);

        foreach (var implementation in implementations)
        {
            var interfaceType = implementation.GetInterfaces().FirstOrDefault(i =>
                i.Name.EndsWith("Service") && i.Assembly == serviceInterfaceType);

            if (interfaceType == null)
                continue;

            services.AddScoped(interfaceType, implementation);
        }
    }
}