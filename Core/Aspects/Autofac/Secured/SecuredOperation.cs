using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Secured;

public class SecuredOperation : MethodInterception
{
    private string[] _roles;
    private IHttpContextAccessor _httpContextAccessor;
    public SecuredOperation(string roles)
    {
        _roles = roles.Split(',');
        _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
    }

    protected override void OnBefore(IInvocation invocation)
    {
        List<string> roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles(); // Kullanıcının rolleri

        foreach (var role in _roles) // Methodların rolleri
        {
            if (roleClaims.Contains(role))
            {
                return;
            }
        }

        throw new Exception("Yetkiniz yok");
    }
}