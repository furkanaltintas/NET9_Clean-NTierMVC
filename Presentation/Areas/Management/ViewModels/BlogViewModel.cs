using Core.Entities.Abstract;
using Entities.Dtos;

namespace Presentation.Areas.Management.ViewModels;

public class BlogViewModel : IViewModel
{
    public BlogViewModel(GetAllBlogDto blogDto)
    {
        Id = blogDto.Id;
        Title = blogDto.Title;
        Slug = blogDto.Slug;
        Content = blogDto.Content;
        Image = blogDto.Image;
        PublishDate = blogDto.PublishDate.ToString("dd/MM/yyyy");
        IsPublish = blogDto.IsPublish == true ? "Yayında" : "Yayında Değil";
        IsTrash = blogDto.IsTrash == true ? "Çöp Kutusunda" : "Çöp Kutusunda Değil";
    }

    public int Id { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
    public string Content { get; set; }
    public string Image { get; set; }
    public string PublishDate { get; set; }
    public string IsPublish { get; set; }
    public string IsTrash { get; set; }
    public int LitterBoxTime { get; set; } = 0; // Çöp kutusu süresi
}
