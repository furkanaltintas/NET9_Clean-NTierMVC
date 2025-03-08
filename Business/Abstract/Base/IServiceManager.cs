namespace Business.Abstract.Base;

public interface IServiceManager
{
    IAboutService AboutService { get; }
    IEducationService EducationService { get; }
    IExperienceService ExperienceService { get; }
    ISkillService SkillService { get; }
    IPortfolioService PortfolioService { get; }
    IBlogService BlogService { get; }
    IServiceService ServiceService { get; }
}