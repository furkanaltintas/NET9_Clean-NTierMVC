using Microsoft.Extensions.DependencyInjection;

namespace Core.Utilities.IoC
{
    public static class ServiceTool
    {
        // Bu nesne, uygulama içinde kaydedilen tüm servislere erişimi temsil eder.
        public static IServiceProvider ServiceProvider { get; private set; }


        public static IServiceCollection Create(IServiceCollection services)
        {
            // Bu metot IServiceCollection türünden bir nesneyi parametre olarak alır ve bu nesneyi kullanarak bir IServiceProvider oluşturur. BuildServiceProvider yöntemi, IServiceCollection içinde kaydedilen tüm servisleri kullanarak bir IServiceProvider nesnesi oluşturur. Oluşturulan ServiceProvider özelliğine atanır ve daha sonra kullanılabilir.
            ServiceProvider = services.BuildServiceProvider();
            return services;
        }
    }
}