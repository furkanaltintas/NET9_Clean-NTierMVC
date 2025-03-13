using Core.Entities.Abstract;
using Entities.Dtos;

namespace Presentation.Areas.Management.ViewModels
{
    public class CertificateViewModel : IViewModel
    {
        public CertificateViewModel(GetAllCertificateDto getAllCertificateDto)
        {
            Id = getAllCertificateDto.Id;
            Name = getAllCertificateDto.Name;
            Image = getAllCertificateDto.Image;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}