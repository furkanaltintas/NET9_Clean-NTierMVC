using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configurations;

public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {
        builder.HasKey(s => s.Id);

        builder
            .Property(s => s.Name)
            .HasMaxLength(100);

        builder
            .Property(s => s.Description)
            .HasMaxLength(500);

        builder
            .Property(s => s.Icon)
            .HasMaxLength(100);

        builder.HasData(
            new Service
            {
                Id = 1,
                Name = "Name",
                Description = "Description",
                Icon = "Icon"
            },
            new Service
            {
                Id = 2,
                Name = "Name2",
                Description = "Description2",
                Icon = "Icon2"
            },
            new Service
            {
                Id = 3,
                Name = "Name3",
                Description = "Description3",
                Icon = "Icon3"
            });
    }
}