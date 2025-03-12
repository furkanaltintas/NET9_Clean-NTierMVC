using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configurations;

public class PortfolioConfiguration : IEntityTypeConfiguration<Entities.Concrete.Portfolio>
{
    public void Configure(EntityTypeBuilder<Entities.Concrete.Portfolio> builder)
    {
        builder.HasKey(p => p.Id);

        builder
            .Property(p => p.Title)
            .HasMaxLength(100);

        builder
            .Property(p => p.SubTitle)
            .HasMaxLength(50);

        builder
            .Property(p => p.Image)
            .HasMaxLength(200);

        builder.HasData(
            new Entities.Concrete.Portfolio
            {
                Id = 1,
                PortfolioCategoryId = 1,
                Title = "Title",
                SubTitle = "title",
                Image = "image"
            },
            new Entities.Concrete.Portfolio
            {
                Id = 2,
                PortfolioCategoryId = 2,
                Title = "Title2",
                SubTitle = "title2",
                Image = "image2"
            },
            new Entities.Concrete.Portfolio
            {
                Id = 3,
                PortfolioCategoryId = 3,
                Title = "Title3",
                SubTitle = "title3",
                Image = "image3"
            });
    }
}