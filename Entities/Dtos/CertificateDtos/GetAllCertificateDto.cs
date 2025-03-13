using Core.Entities.Abstract;

namespace Entities.Dtos;

public class GetAllCertificateDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Image { get; set; }
}