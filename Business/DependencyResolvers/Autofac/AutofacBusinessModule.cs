using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using System.Reflection;
using Module = Autofac.Module;

namespace Business.DependencyResolvers.Autofac;

public class AutofacBusinessModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {

        Assembly assembly = Assembly.GetExecutingAssembly(); // Mevcut assembly'e ulaştık  (Business)


        builder.RegisterAssemblyTypes(assembly) // Bu assemblyde ki bütüp tipleri kayıt et
            .AsImplementedInterfaces() // Kaydedilen tiplerin uyguladığı arayüzleri DI konteynerine kaydetmesini sağlar.
            .EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance(); // Kaydedilen tiplerin tek bir örneğini oluşturur ve bu örneği tüm bağımlılıklar için paylaşılabilir bir hale getirir.
    }
}