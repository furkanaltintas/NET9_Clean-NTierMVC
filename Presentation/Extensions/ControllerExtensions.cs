using Core.Entities.Abstract;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Presentation.Helpers;
using IResult = Portfolio.Core.Utilities.Results.Abstract.IResult;

namespace Presentation.Extensions;

public static class ControllerExtensions
{
    /// <summary>
    /// Başarı durumunda belirli bir aksiyona yönlendirir, başarısız durumda View döndürür.
    /// Success -> RedirectToAction() | Error -> View(data)
    /// </summary>
    public static IActionResult ResponseRedirectAction<T>(
        this Controller controller,
        IDataResult<T> result,
        IToastNotification toastNotification,
        string actionName = null,
        string? controllerName = null)
    {
        ShowNotification(toastNotification, result);

        return result.ResultStatus == ResultStatus.Success
            ? controller.RedirectToAction(actionName ?? nameof(Index), controllerName)
            : controller.View(result.Data);
    }


    /// <summary>
    /// IResult kullanıp data yollamak için
    /// Success -> RedirectToAction | Error -> View(data)
    /// </summary>
    public static IActionResult ResponseRedirectAction(
    this Controller controller,
    IResult result,
    IToastNotification toastNotification,
    object data,
    string? actionName = null,
    string? controllerName = null)
    {
        var isSuccess = ResultHelper.IsSuccess(result);
        ShowNotification(toastNotification, result);

        return isSuccess
            ? controller.RedirectToAction(actionName ?? nameof(Index), controllerName)
            : controller.View(data);
    }



    /// <summary>
    /// Başarı veya hata durumuna göre belirli bir aksiyona yönlendirir.
    /// RedirectToAction
    /// </summary>
    public static IActionResult ResponseRedirectAction(
        this Controller controller,
        IResult result,
        IToastNotification toastNotification,
        string? actionName = null,
        string? controllerName = null)
    {
        ShowNotification(toastNotification, result);
        return controller.RedirectToAction(actionName ?? nameof(Index), controllerName);
    }



    /// <summary>
    /// Başarı durumunda View döndürür data ile beraber, başarısız durumda belirli bir aksiyona yönlendirir.
    /// Success -> View(data) | Error -> RedirectToAction(Index) NOT: Mesaj Dönmez
    /// </summary>
    public static IActionResult ResponseView<T>(
        this Controller controller,
        IDataResult<T> result,
        string? actionName = null)
    {
        return result.ResultStatus == ResultStatus.Success
            ? controller.View(result.Data)
            : controller.RedirectToAction(actionName ?? nameof(Index));
    }

    /// <summary>
    /// Başarı durumunda ViewModel döndürür data ile beraber, başarısız durumda belirli bir aksiyona yönlendirir.
    /// Success -> View(data) | Error -> RedirectToAction(Index) NOT: Mesaj Dönmez
    /// </summary>
    public static IActionResult ResponseViewModel<T>(
        this Controller controller,
        IDataResult<T> result,
        IViewModel data,
        string? actionName = null)
    {
        return result.ResultStatus == ResultStatus.Success
            ? controller.View(data)
            : controller.RedirectToAction(actionName ?? nameof(Index));
    }


    /// <summary>
    /// IList<TDto> -> TViewModel
    /// </summary>
    public static IActionResult ResponseViewModel<TDto, TViewModel>(this Controller controller, IDataResult<IList<TDto>> result)
        where TDto : IDto
        where TViewModel : IViewModel
    {
        var viewModels = result.Data.Select(dto => (TViewModel)Activator.CreateInstance(typeof(TViewModel), dto)).ToList();
        return controller.View(viewModels);
    }



    /// <summary>
    /// <TDto> -> TViewModel
    /// </summary>
    public static IActionResult ResponseViewModel<TDto, TViewModel>(this Controller controller, IDataResult<TDto> result)
    where TDto : IDto
    where TViewModel : IViewModel
    {
        var viewModels = (TViewModel)Activator.CreateInstance(typeof(TViewModel), result.Data);
        return controller.View(viewModels);
    }



    /// <summary>
    /// Bildirimleri gösteren yardımcı metod.
    /// </summary>
    private static void ShowNotification(IToastNotification toastNotification, IResult result)
    {
        if (result.ResultStatus == ResultStatus.Validation)
            NotificationHelper.ShowValidation(toastNotification, result.Message);
        else if (result.ResultStatus == ResultStatus.Error)
            NotificationHelper.ShowError(toastNotification, result.Message);
        else
            NotificationHelper.ShowSuccess(toastNotification, result.Message);

        //ShowNotification(toastNotification, ResultHelper.IsSuccess(result), result.Message);
    }
}
