using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.Helpers.Images.Abstract;
using Core.Helpers.Images.Concrete;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace Core.DependencyResolvers;

public class CoreModule : ICoreModule
{
    public void Load(IServiceCollection services)
    {
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        services.AddSingleton<ICacheManager, MemoryCacheManager>();
        services.AddScoped<IFileNameHelper, FileNameHelper>();
        services.AddScoped<IImageUploader, ImageUploader>();
        services.AddScoped<IImageHelper, ImageHelper>();
        services.AddSingleton<Stopwatch>();
        services.AddMemoryCache();

    }
}