using Business.AutoMapper.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace Business.DependencyResolvers.Microsoft;

public static class MicrosoftDependencies
{
    public static void AddCustomDependencies(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMappingProfile).Assembly);
    }
}