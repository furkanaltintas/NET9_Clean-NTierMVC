using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configurations;

public class CertificateConfiguration : IEntityTypeConfiguration<Certificate>
{
    public void Configure(EntityTypeBuilder<Certificate> builder)
    {
        builder.HasKey(c => c.Id);

        builder
            .Property(c => c.Title)
            .HasMaxLength(200)
            .IsRequired();

        builder
            .Property(c => c.Image)
            .HasMaxLength(256)
            .IsRequired();
    }
}