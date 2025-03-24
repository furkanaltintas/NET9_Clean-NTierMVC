using Core.Entities.Concrete;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Business.DependencyResolvers.Microsoft;

public static class MicrosoftDependencies
{
    public static void AddCustomDependencies(this IServiceCollection services)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();

        services.AddAssemblyServices(assembly); // DI

        services.AddSubClassesOfType(assembly, typeof(BaseBusinessRules));

        services.AddValidatorsFromAssembly(assembly);
        services.AddAutoMapper(assembly);
    }


    // Ek görevler
    private static IServiceCollection AddSubClassesOfType
    (this IServiceCollection services,
    Assembly assembly,
    Type type,
    Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null)
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();

        foreach (var item in types)
            if (addWithLifeCycle is null)
                services.AddScoped(item);
            else
                addWithLifeCycle(services, type);
        return services;
    }
}