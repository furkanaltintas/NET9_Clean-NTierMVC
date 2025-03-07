using Business.Abstract;
using Business.Abstract.Base;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Concrete.Base;

public class ServiceManager : IServiceManager
{
    private readonly IServiceProvider _serviceProvider;

    public ServiceManager(IServiceProvider serviceProvider) { _serviceProvider = serviceProvider; }

    public IAboutService AboutService => _serviceProvider.GetService<IAboutService>();
}
