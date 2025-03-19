using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder
            .Property(u => u.CvLink)
            .HasMaxLength(255)
            .IsRequired(false);

        builder.HasData(
            new User
            {
                Id = 1,
                UserName = "FRKN",
                FirstName = "Furkan",
                LastName = "Altıntaş",
                Email = "furkanaltintas785@gmail.com",
                Password = "1234",
                City = "İstanbul",
                Profession = "NET DEVELOPER",
                Profile = "frkn",
                Birthday = new DateTime(2000, 11, 3),
                Phone = "+90 555 555 55 55"
            });
    }
}