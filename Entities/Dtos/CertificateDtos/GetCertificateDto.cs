using Core.Entities.Abstract;

namespace Entities.Dtos;

public class GetCertificateDto : IDto
{
    public int Id { get; set; }
    public string Image { get; set; }
}