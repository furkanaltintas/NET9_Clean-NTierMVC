using Core.DataAccess.Abstract;
using PortfolioApp.Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IAboutRepository : IEntityRepository<About>
    {
        string Test();
    }
}