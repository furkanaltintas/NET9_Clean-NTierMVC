﻿using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Caching;

public class CacheAspect : MethodInterception
{
    private int _duration;
    private ICacheManager _cacheManager;

    public CacheAspect(int duration = 60)
    {
        _duration = duration;
        _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
    }

    // ProductManager.GetByCategory(1, abc)
    public override void Intercept(IInvocation invocation)
    {
        var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}"); // "Business.Abstract.IProductService.GetAllByCategoryAsync"
        var arguments = invocation.Arguments.ToList(); // "1"
        var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})"; // "Business.Abstract.IProductService.GetAllByCategoryAsync(1)"

        // Eğer bu key daha önce eklenmişse
        if (_cacheManager.IsAdd(key))
        {
            invocation.ReturnValue = _cacheManager.Get(key);
            return;
        }

        invocation.Proceed();
        _cacheManager.Add(key, invocation.ReturnValue, _duration);
    }
}