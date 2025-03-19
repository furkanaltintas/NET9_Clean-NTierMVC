using Business.Modules.TypeOfEmployments.Services;
using Microsoft.AspNetCore.Mvc;
using Presentation.Areas.Management.Controllers.Base;
using Presentation.Extensions;

namespace Presentation.Areas.Management.Controllers;

public class TypeOfEmploymentController : BaseController
{
    private readonly ITypeOfEmploymentService _typeOfEmploymentService;

    public TypeOfEmploymentController(ITypeOfEmploymentService typeOfEmploymentService)
    {
        _typeOfEmploymentService = typeOfEmploymentService;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _typeOfEmploymentService.GetAllTypeOfEmploymentsAsync();
        return this.ResponseView(result);
    }
}