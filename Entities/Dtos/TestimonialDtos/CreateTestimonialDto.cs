using Core.Entities.Abstract;
using Microsoft.AspNetCore.Http;

namespace Entities.Dtos;

public class CreateTestimonialDto : IDto
{
    public string FullName { get; set; }
    public string Message { get; set; }
    public IFormFile Photo { get; set; }
}