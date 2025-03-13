using Core.Entities.Abstract;

namespace Entities.Dtos;

public class GetTestimonialDto : IDto
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Message { get; set; }
    public string Image { get; set; }
}