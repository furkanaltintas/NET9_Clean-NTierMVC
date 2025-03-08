using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configurations;

public class PortfolioConfiguration : IEntityTypeConfiguration<Entities.Concrete.Portfolio>
{
    public void Configure(EntityTypeBuilder<Entities.Concrete.Portfolio> builder)
    {
        throw new NotImplementedException();
    }
}