﻿using Prosigliere.Challenge.Domain.Repositories;
using Prosigliere.Challenge.Infrastructure.Repositories;

namespace Prosigliere.Challenge.WebApi.ConfigurationExtensions;
public static class RepositoryExtensions
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped(typeof(IRepositoryAsync<>), typeof(RepositoryBaseAsync<>));

        var types = typeof(BlogPostRepository).Assembly.GetTypes()
            .Where(t => t.Name.EndsWith("Repository") && t.IsClass && !t.IsAbstract);

        foreach (var impl in types)
        {
            var interfaces = impl.GetInterfaces()
                .Where(i => i.Name.EndsWith("Repository"));

            foreach (var iface in interfaces)
            {
                services.AddScoped(iface, impl);
            }
        }
    }
}
