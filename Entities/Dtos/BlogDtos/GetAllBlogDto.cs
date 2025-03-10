using Core.Entities.Abstract;

namespace Entities.Dtos;

public class GetAllBlogDto : IDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
    public string Content { get; set; }
    public string Image { get; set; }
    public DateTime PublishDate { get; set; }
    public bool IsPublish { get; set; } = false;
    public bool IsTrash { get; set; } = false; // false ise çöp kutusuna gidecek. (7 gün süre verilecek. Süre bittikten sonra tamamen silinecek)
    public int LitterBoxTime { get; set; } = 0; // Çöp kutusu süresi
}