using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configurations;

public class EducationConfiguration : IEntityTypeConfiguration<Education>
{
    public void Configure(EntityTypeBuilder<Education> builder)
    {
        builder.HasKey(e => e.Id);

        builder
            .Property(e => e.Title)
            .HasMaxLength(100);

        builder
            .Property(e => e.Degree)
            .HasMaxLength(50);

        builder
            .Property(e => e.Department)
            .HasMaxLength(100);

        builder
            .Property(e => e.Description)
            .HasMaxLength(1000);

        builder.HasData(
            new Education
            {
                Id = 1,
                Title = "Title",
                Degree = "Title",
                Department = "Title",
                Description = "Title",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            },
            new Education
            {
                Id = 2,
                Title = "Title2",
                Degree = "Title2",
                Department = "Title2",
                Description = "Title2",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            },
            new Education
            {
                Id = 3,
                Title = "Title3",
                Degree = "Title3",
                Department = "Title3",
                Description = "Title3",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now
            });
    }
}