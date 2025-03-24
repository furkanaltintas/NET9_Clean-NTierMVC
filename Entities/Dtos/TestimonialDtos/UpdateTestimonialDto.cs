using Core.Entities.Abstract;
using Microsoft.AspNetCore.Http;

namespace Entities.Dtos;

public class UpdateTestimonialDto : IDto
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public string Message { get; set; }
    public string Image { get; set; }
    public IFormFile Photo { get; set; }
}