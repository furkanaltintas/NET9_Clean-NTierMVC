using Core.Entities.Abstract;
using Microsoft.AspNetCore.Http;

namespace Entities.Dtos;

public class CreateBlogDto : IDto
{
    public string Title { get; set; }
    public string Content { get; set; }
    public IFormFile Photo { get; set; }
    public DateTime PublishDate { get; set; }
    public bool IsPublish { get; set; }
}