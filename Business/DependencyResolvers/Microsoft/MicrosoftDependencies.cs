using Business.AutoMapper.Profiles;
using Business.Helpers.Images.Abstract;
using Business.Helpers.Images.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Business.DependencyResolvers.Microsoft;

public static class MicrosoftDependencies
{
    public static void AddCustomDependencies(this IServiceCollection services)
    {
        services.AddScoped<IImageHelper, ImageHelper>();
        services.AddScoped<IFileNameHelper, FileNameHelper>();

        services.AddHttpContextAccessor();

        services.AddScoped<IImageUploader, ImageUploader>();
        services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();

        services.AddAutoMapper(typeof(AutoMappingProfile).Assembly);
    }
}