using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Concrete.EntityFramework.Configurations;

public class BlogConfiguration : IEntityTypeConfiguration<Blog>
{
    public void Configure(EntityTypeBuilder<Blog> builder)
    {
        builder.HasKey(b => b.Id);

        builder
            .Property(b => b.Title)
            .HasMaxLength(100);
        builder
            .Property(b => b.Slug)
            .HasMaxLength(150);
        builder
            .Property(b => b.Content)
            .HasMaxLength(2000);
        builder
            .Property(b => b.Image)
            .HasMaxLength(250);

        builder.HasData(
            new Blog
            {
                Id = 1,
                Title = "Title",
                Slug = "title",
                Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                Image = "title",
                PublishDate = DateTime.Now,
                IsPublish = true,
                IsTrash = false,
                LitterBoxTime = 0
            },
            new Blog
            {
                Id = 2,
                Title = "Title 2",
                Slug = "title-2",
                Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                Image = "title2",
                PublishDate = DateTime.Now,
                IsPublish = true,
                IsTrash = false,
                LitterBoxTime = 0
            },
            new Blog
            {
                Id = 3,
                Title = "Title3",
                Slug = "title-3",
                Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                Image = "title3",
                PublishDate = DateTime.Now,
                IsPublish = true,
                IsTrash = false,
                LitterBoxTime = 0
            });
    }
}