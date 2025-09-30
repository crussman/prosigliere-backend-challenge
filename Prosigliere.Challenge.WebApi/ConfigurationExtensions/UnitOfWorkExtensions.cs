using Prosigliere.Challenge.Domain.UnitOfWork;
using Prosigliere.Challenge.Infrastructure.UnitOfWork;

namespace Prosigliere.Challenge.WebApi.ConfigurationExtensions;

public static class UnitOfWorkExtensions
{
    public static void AddUnitOfWork(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWorkAsync, UnitOfWorkAsync>();
    }
}