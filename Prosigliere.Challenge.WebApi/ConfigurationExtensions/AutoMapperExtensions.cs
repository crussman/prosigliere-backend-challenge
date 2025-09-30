using Prosigliere.Challenge.Application.Mappings;
using Prosigliere.Challenge.Infrastructure.Mappings;

namespace Prosigliere.Challenge.WebApi.ConfigurationExtensions;

public static class AutoMapperExtensions
{
    public static void AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(
            configAction => { },
            typeof(CommandToValueObjectMappingProfile),
            typeof(EntityToDtoMappingProfile),
            typeof(EntityToValueObjectMappingProfile));
    }
}
