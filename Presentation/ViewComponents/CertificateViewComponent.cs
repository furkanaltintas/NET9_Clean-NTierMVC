using Business.Modules.Certificates.Services;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.ViewComponents;

public class CertificateViewComponent : ViewComponent
{
    private readonly ICertificateService _certificateService;

    public CertificateViewComponent(ICertificateService certificateService)
    {
        _certificateService = certificateService;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var result = await _certificateService.GetAllCertificatesAsync();
        return View(result.Data);
    }
}