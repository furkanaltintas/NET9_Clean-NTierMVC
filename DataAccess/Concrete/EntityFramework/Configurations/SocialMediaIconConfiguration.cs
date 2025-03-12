using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configurations;

public class SocialMediaIconConfiguration : IEntityTypeConfiguration<SocialMediaIcon>
{
    public void Configure(EntityTypeBuilder<SocialMediaIcon> builder)
    {
        builder.HasKey(s => s.Id);

        builder
            .Property(s => s.Name)
            .HasMaxLength(30)
            .IsRequired();

        builder
            .Property(s => s.Icon)
            .HasMaxLength(20)
            .IsRequired();

        builder
            .Property(s => s.Link)
            .HasMaxLength(100)
            .IsRequired();

        builder.HasData(
            new SocialMediaIcon
            {
                Id = 1,
                Name = "Name",
                Icon = "Icon",
                Link = "Link"
            },
            new SocialMediaIcon
            {
                Id = 2,
                Name = "Name2",
                Icon = "Icon2",
                Link = "Link2"
            },
            new SocialMediaIcon
            {
                Id = 3,
                Name = "Name3",
                Icon = "Icon3",
                Link = "Link3"
            },
            new SocialMediaIcon
            {
                Id = 4,
                Name = "Name4",
                Icon = "Icon4",
                Link = "Link4"
            },
            new SocialMediaIcon
            {
                Id = 5,
                Name = "Name5",
                Icon = "Icon5",
                Link = "Link5"
            });
    }
}