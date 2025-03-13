using Core.Entities.Abstract;
using Microsoft.AspNetCore.Http;

namespace Entities.Dtos;

public class UpdateCertificateDto : IDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Image { get; set; }

    public IFormFile Photo { get; set; }
}