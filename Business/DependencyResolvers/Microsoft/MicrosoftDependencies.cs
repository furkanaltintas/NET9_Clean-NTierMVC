using Business.AutoMapper.Profiles;
using Core.Entities.Concrete;
using Core.Helpers.Images.Abstract;
using Core.Helpers.Images.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Business.DependencyResolvers.Microsoft;

public static class MicrosoftDependencies
{
    public static void AddCustomDependencies(this IServiceCollection services)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();

        services.AddScoped<IRepository, Repository>();
        services.AddAssemblyServices(assembly);

        services.AddSubClassesOfType(assembly, typeof(BaseBusinessRules));

        services.AddScoped<IImageHelper, ImageHelper>();
        services.AddScoped<IFileNameHelper, FileNameHelper>();

        services.AddScoped<IImageUploader, ImageUploader>();

        services.AddAutoMapper(typeof(AutoMappingProfile).Assembly);
    }

    public static IServiceCollection AddSubClassesOfType
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