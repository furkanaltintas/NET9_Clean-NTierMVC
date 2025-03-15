using Business.Abstract.Base;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Presentation.Areas.Management.Controllers.Base;
using Presentation.Areas.Management.ViewModels;
using Presentation.Extensions;
using System.Threading.Tasks;

namespace Presentation.Areas.Management.Controllers;

public class CertificateController : BaseController
{
    public CertificateController(IServiceManager serviceManager, IToastNotification toastNotification) : base(serviceManager, toastNotification)
    {
    }

    public async Task<IActionResult> Index()
    {
        var result = await _serviceManager.CertificateService.GetAllAsync();
        return this.ResponseViewModel<GetAllCertificateDto, CertificateViewModel>(result);
    }


    public IActionResult Add() => View();


    [HttpPost]
    public async Task<IActionResult> Add(CreateCertificateDto createCertificateDto)
    {
        var result = await _serviceManager.CertificateService.AddCertificateAsync(createCertificateDto);
        return this.ResponseRedirectAction(result, _toastNotification, createCertificateDto);
    }


    public async Task<IActionResult> Update(int certificateId)
    {
        var result = await _serviceManager.CertificateService.GetUpdateCertificateAsync(certificateId);
        return this.ResponseView(result);
    }


    [HttpPost]
    public async Task<IActionResult> Update(UpdateCertificateDto updateCertificateDto)
    {
        var result = await _serviceManager.CertificateService.UpdateCertificateAsync(updateCertificateDto);
        return this.ResponseRedirectAction(result, _toastNotification, updateCertificateDto);
    }


    public async Task<IActionResult> Delete(int certificateId)
    {
        var result = await _serviceManager.CertificateService.DeleteCertificateAsync(certificateId);
        return this.ResponseRedirectAction(result, _toastNotification);
    }
}