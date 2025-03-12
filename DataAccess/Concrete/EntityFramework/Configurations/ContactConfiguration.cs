using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configurations;

public class ContactConfiguration : IEntityTypeConfiguration<Contact>
{
    public void Configure(EntityTypeBuilder<Contact> builder)
    {
        builder.HasKey(c => c.Id);

        builder
            .Property(c => c.FullName)
            .HasMaxLength(100);

        builder
            .Property(c => c.Email)
            .HasMaxLength(100);

        builder
            .Property(c => c.Message)
            .HasMaxLength(1000);
    }
}