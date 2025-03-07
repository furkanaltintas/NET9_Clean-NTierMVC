using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PortfolioApp.Entities.Concrete;

namespace DataAccess.Concrete.EntityFramework.Configurations;

public class AboutConfiguration : IEntityTypeConfiguration<About>
{
    public void Configure(EntityTypeBuilder<About> builder)
    {
        throw new NotImplementedException();
    }
}