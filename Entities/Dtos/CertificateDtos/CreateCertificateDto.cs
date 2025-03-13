using Core.Entities.Abstract;
using Microsoft.AspNetCore.Http;

namespace Entities.Dtos;

public class CreateCertificateDto : IDto
{
    public string Title { get; set; }
    public string Image { get; set; }

    public IFormFile Photo { get; set; }
}