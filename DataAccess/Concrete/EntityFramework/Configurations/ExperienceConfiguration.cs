using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configurations;

public class ExperienceConfiguration : IEntityTypeConfiguration<Experience>
{
    public void Configure(EntityTypeBuilder<Experience> builder)
    {
        builder.HasKey(e => e.Id);

        builder
            .Property(e => e.Title)
            .HasMaxLength(75);

        builder
            .Property(e => e.Company)
            .HasMaxLength(100);

        builder
            .Property(e => e.Description)
            .HasMaxLength(1000);

        builder
            .Property(e => e.Location)
            .HasMaxLength(50);

        builder
            .Property(e => e.TypeOfEmploymentId)
            .IsRequired(false);

        builder
            .HasOne(e => e.TypeOfEmployment)
            .WithMany(t => t.Experiences)
            .HasForeignKey(e => e.TypeOfEmploymentId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasData(
            new Experience
            {
                Id = 1,
                TypeOfEmploymentId = 1,
                Title = "Title",
                Company = "Title",
                Description = "Title",
                Location = "Title",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
            },
            new Experience
            {
                Id = 2,
                TypeOfEmploymentId = 2,
                Title = "Title2",
                Company = "Title2",
                Description = "Title2",
                Location = "Title2",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
            },
            new Experience
            {
                Id = 3,
                TypeOfEmploymentId = 3,
                Title = "Title3",
                Company = "Title3",
                Description = "Title3",
                Location = "Title3",
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
            });
    }
}