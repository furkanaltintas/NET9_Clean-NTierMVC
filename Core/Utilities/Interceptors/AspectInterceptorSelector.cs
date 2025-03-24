using Castle.DynamicProxy;
using System.Reflection;

namespace Core.Utilities.Interceptors;

public class AspectInterceptorSelector : IInterceptorSelector
{
    public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
    {
        var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>(inherit: true).ToList();

        //var methodAttributes = type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>(inherit: true);
        // Eski kod

        var methodAttributes = type.GetMethods()
            .FirstOrDefault(m => m.Name == method.Name && m.GetParameters().Length == method?.GetParameters().Length)?
            .GetCustomAttributes<MethodInterceptionBaseAttribute>(inherit: true)
            ?? Enumerable.Empty<MethodInterceptionBaseAttribute>();

        classAttributes.AddRange(methodAttributes);

        return classAttributes.OrderBy(x => x.Priority).ToArray();
    }
}