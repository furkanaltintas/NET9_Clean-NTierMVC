using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configurations;

public class TypeOfEmploymentConfiguration : IEntityTypeConfiguration<TypeOfEmployment>
{
    public void Configure(EntityTypeBuilder<TypeOfEmployment> builder)
    {
        builder.HasKey(t => t.Id);

        builder
            .Property(t => t.Name)
            .HasMaxLength(30)
            .IsRequired();

        builder
            .HasMany(t => t.Experiences)
            .WithOne(e => e.TypeOfEmployment)
            .HasForeignKey(e => e.TypeOfEmploymentId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.HasData(
            new TypeOfEmployment
            {
                Id = 1,
                Name = "Sürekli / Tam Zamanlı"
            }, new TypeOfEmployment
            {
                Id = 2,
                Name = "Yarı Zamanlı"
            }, new TypeOfEmployment
            {
                Id = 3,
                Name = "Stajyer"
            }, new TypeOfEmployment
            {
                Id = 4,
                Name = "Dönemsel"
            }, new TypeOfEmployment
            {
                Id = 5,
                Name = "Serbest"
            }, new TypeOfEmployment
            {
                Id = 6,
                Name = "Gönüllü"
            });
    }
}