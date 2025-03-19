using Business.Modules.Certificates.Services;
using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Presentation.Areas.Management.Controllers.Base;
using Presentation.Areas.Management.ViewModels;
using Presentation.Extensions;

namespace Presentation.Areas.Management.Controllers;

public class CertificateController : BaseController
{
    private readonly ICertificateService _certificateService;

    public CertificateController(ICertificateService certificateService)
    {
        _certificateService = certificateService;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _certificateService.GetAllCertificatesAsync();
        return this.ResponseViewModel<GetAllCertificateDto, CertificateViewModel>(result);
    }


    public IActionResult Add() => View();


    [HttpPost]
    public async Task<IActionResult> Add(CreateCertificateDto createCertificateDto)
    {
        var result = await _certificateService.CreateCertificateAsync(createCertificateDto);
        return this.ResponseRedirectAction(result, ToastNotification, createCertificateDto);
    }


    public async Task<IActionResult> Update(int certificateId)
    {
        var result = await _certificateService.GetCertificateForUpdateByIdAsync(certificateId);
        return this.ResponseView(result);
    }


    [HttpPost]
    public async Task<IActionResult> Update(UpdateCertificateDto updateCertificateDto)
    {
        var result = await _certificateService.UpdateCertificateAsync(updateCertificateDto);
        return this.ResponseRedirectAction(result, ToastNotification, updateCertificateDto);
    }


    public async Task<IActionResult> Delete(int certificateId)
    {
        var result = await _certificateService.DeleteCertificateByIdAsync(certificateId);
        return this.ResponseRedirectAction(result, ToastNotification);
    }
}