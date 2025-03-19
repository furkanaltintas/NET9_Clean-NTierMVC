using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configurations;

public class SkillConfiguration : IEntityTypeConfiguration<Skill>
{
    public void Configure(EntityTypeBuilder<Skill> builder)
    {
        builder.HasKey(s => s.Id);

        builder
            .Property(s => s.Name)
            .HasMaxLength(50);

        builder
            .Property(s => s.Point)
            .IsRequired();

        builder
            .ToTable(t => t.HasCheckConstraint("CK_Skill_Point", "[Point] BETWEEN 0 AND 100"));

        builder.HasData(
            new Skill
            {
                Id = 1,
                Name = "Name",
                Point = 10
            },
            new Skill
            {
                Id = 2,
                Name = "Name2",
                Point = 20
            },
            new Skill
            {
                Id = 3,
                Name = "Name3",
                Point = 30
            },
            new Skill
            {
                Id = 4,
                Name = "Name4",
                Point = 40
            },
            new Skill
            {
                Id = 5,
                Name = "Name5",
                Point = 50
            },
            new Skill
            {
                Id = 6,
                Name = "Name6",
                Point = 60
            },
            new Skill
            {
                Id = 7,
                Name = "Name7",
                Point = 70
            });
    }
}