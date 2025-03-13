using Business.Abstract;
using Business.Abstract.Base;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Concrete.Base;

#region V1
public class ServiceManager : IServiceManager
{
    private readonly IServiceProvider _serviceProvider;

    public ServiceManager(IServiceProvider serviceProvider) { _serviceProvider = serviceProvider; }


    public IAboutService AboutService => _serviceProvider.GetService<IAboutService>();
    public IEducationService EducationService => _serviceProvider.GetService<IEducationService>();
    public IExperienceService ExperienceService => _serviceProvider.GetService<IExperienceService>();
    public ISkillService SkillService => _serviceProvider.GetService<ISkillService>();
    public IPortfolioService PortfolioService => _serviceProvider.GetService<IPortfolioService>();
    public IBlogService BlogService => _serviceProvider.GetService<IBlogService>();
    public IServiceService ServiceService => _serviceProvider.GetService<IServiceService>();
    public IContactService ContactService => _serviceProvider.GetService<IContactService>();
    public IUserService UserService => _serviceProvider.GetService<IUserService>();
    public ISocialMediaService SocialMediaService => _serviceProvider.GetService<ISocialMediaService>();
    public IPortfolioCategoryService PortfolioCategoryService => _serviceProvider.GetService<IPortfolioCategoryService>();
    public ITypeOfEmploymentService TypeOfEmploymentService => _serviceProvider.GetService<ITypeOfEmploymentService>();
    public ICertificateService CertificateService => _serviceProvider.GetService<ICertificateService>();
}
#endregion
