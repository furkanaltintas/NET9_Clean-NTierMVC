using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configurations;

public class TestimonialConfiguration : IEntityTypeConfiguration<Testimonial>
{
    public void Configure(EntityTypeBuilder<Testimonial> builder)
    {
        builder.HasKey(t => t.Id);

        builder
            .Property(t => t.FullName)
            .HasMaxLength(75)
            .IsRequired();

        builder
            .Property(t => t.Message)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(t => t.Image)
            .HasMaxLength(125)
            .IsRequired();
    }
}