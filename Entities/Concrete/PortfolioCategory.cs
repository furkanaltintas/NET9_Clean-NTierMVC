using Core.Entities.Abstract;
using Core.Entities.Concrete;

namespace Entities.Concrete;

public class PortfolioCategory : BaseEntity, IEntity
{
    public string Name { get; set; }

    public ICollection<Portfolio> Portfolios { get; set; }
}