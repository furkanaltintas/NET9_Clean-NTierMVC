using Core.Entities.Abstract;
using Microsoft.AspNetCore.Http;

namespace Entities.Dtos;

public class UpdateBlogDto : IDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string Image { get; set; }
    public IFormFile Photo { get; set; }
    public DateTime PublishDate { get; set; }
    public bool IsPublish { get; set; } = false;
    public bool IsTrash { get; set; } = false; // false ise çöp kutusuna gidecek. (7 gün süre verilecek. Süre bittikten sonra tamamen silinecek)
    public int LitterBoxTime { get; set; } = 0; // Çöp kutusu süresi
}