using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions;

public static class ServiceCollectionExtensions
{
    // Merkezi modülleri array olarak ekledik
    public static IServiceCollection AddDependencyResolvers(this IServiceCollection services, ICoreModule[] modules)
    {
        foreach (var module in modules)
        {
            module.Load(services); // Bütün modülleri ekledik
        }

        return ServiceTool.Create(services);
    }
}