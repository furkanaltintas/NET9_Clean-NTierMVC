using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Business.DependencyResolvers;

public static class ServiceExtensions
{
    public static void AddAssemblyServices(this IServiceCollection services, Assembly assembly)
    {
        var allTypes = assembly.GetExportedTypes(); // // Derlemeden tüm erişilebilir tipleri bir defa al

        // Hizmet tiplerini filtrelemeye yarar
        var serviceTypes = allTypes
            .Where(p => p.IsInterface && !p.IsClass && p.Name.StartsWith("I") && p.Name.EndsWith("Service"))
            .ToList();

        foreach (var serviceType in serviceTypes)
        {
            // İlgili yönetici tipini almaya yarıyor
            var managerTypeName = GetManagerTypeName(serviceType);
            var managerType = allTypes.FirstOrDefault(t => t.Name == managerTypeName);

            // Yönetici tipi bulunduysa, servisi ekle
            if (managerType != null)
                services.AddScoped(serviceType, managerType);
        }
    }

    // Manager tipinin adını elde etme
    private static string GetManagerTypeName(Type serviceType)
    {
        return serviceType.Name
            .Replace("Service", "Manager")
            .Substring(1); // "IAuthService" -> "AuthManager"
    }
}