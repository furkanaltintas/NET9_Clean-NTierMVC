using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.DependencyResolvers.Autofac;
using DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Presentation.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Scoped);

        services.AddRouting(options =>
        {
            options.LowercaseUrls = true;
        });

        services.AddSession();

        return services;
    }

    public static ConfigureHostBuilder ConfigureAutofac(this ConfigureHostBuilder host)
    {
        host.UseServiceProviderFactory(new AutofacServiceProviderFactory(builder =>
        {
            builder.RegisterModule(new AutofacBusinessModule());
        }));

        return host;
    }
}