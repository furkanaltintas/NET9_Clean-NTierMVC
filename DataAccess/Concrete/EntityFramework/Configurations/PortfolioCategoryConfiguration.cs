using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configurations;

public class PortfolioCategoryConfiguration : IEntityTypeConfiguration<PortfolioCategory>
{
    public void Configure(EntityTypeBuilder<PortfolioCategory> builder)
    {
        builder.HasKey(p => p.Id);

        builder
            .Property(p => p.Name)
            .HasMaxLength(25);

        builder.HasData(
            new PortfolioCategory
            {
                Id = 1,
                Name = "Test"
            },
            new PortfolioCategory
            {
                Id = 2,
                Name = "Test2"
            },
            new PortfolioCategory
            {
                Id = 3,
                Name = "Test3"
            });
    }
}