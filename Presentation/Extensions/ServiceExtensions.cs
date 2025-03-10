using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using NToastNotify;

namespace Presentation.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Singleton, ServiceLifetime.Singleton);

        services.AddRouting(options =>
        {
            options.LowercaseUrls = true;
        });

        services
            .AddControllersWithViews()
            .AddNToastNotifyToastr(new()
            {
                PositionClass = ToastPositions.TopRight,
                TimeOut = 5000,
                ProgressBar = true,
                CloseButton = true,
            })
            .AddRazorRuntimeCompilation();

        services.AddSession();

        return services;
    }

    public static ConfigureHostBuilder ConfigureAutofac(this ConfigureHostBuilder host)
    {
        host.UseServiceProviderFactory(new AutofacServiceProviderFactory(builder =>
        {
            builder.RegisterModule(new AutofacBusinessModule());
        }));

        //host.ConfigureContainer<ContainerBuilder>(container =>
        //{
        //    container.RegisterType<ValidationAspect>();
        //    container.RegisterType<CacheAspect>();

        //    container.RegisterAssemblyTypes(typeof(BlogManager).Assembly)
        //    .AsImplementedInterfaces()
        //    .EnableInterfaceInterceptors()
        //    .InterceptedBy(typeof(ValidationAspect));
        //});

        return host;
    }
}