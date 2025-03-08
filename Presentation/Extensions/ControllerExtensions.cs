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
    object? data,
    bool isSuccess,
    string message,
    IToastNotification toastNotification,
    string actionName = null,
    string? controllerName = null)
    {
        ShowNotification(toastNotification, isSuccess, message);

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
        string actionName,
        string? controllerName = null)
    {
        ShowNotification(toastNotification, result);
        return controller.RedirectToAction(actionName, controllerName);
    }



    /// <summary>
    /// Başarı durumunda View döndürür data ile beraber, başarısız durumda belirli bir aksiyona yönlendirir.
    /// Success -> View(data) | Error -> RedirectToAction(Index) NOT: Mesaj Dönmez
    /// </summary>
    public static IActionResult ResponseView<T>(
        this Controller controller,
        IDataResult<T> result,
        IToastNotification toastNotification,
        string? actionName = null)
    {
        //ShowNotification(toastNotification, result);

        return result.ResultStatus == ResultStatus.Success
            ? controller.View(result.Data)
            : controller.RedirectToAction(actionName ?? nameof(Index));
    }



    /// <summary>
    /// Bildirimleri gösteren yardımcı metod.
    /// </summary>
    private static void ShowNotification(IToastNotification toastNotification, IResult result)
    {
        ShowNotification(toastNotification, result.ResultStatus == ResultStatus.Success, result.Message);
    }



    /// <summary>
    /// Alternatif olarak direkt başarı durumu ve mesaj alarak bildirim gösteren metod.
    /// </summary>
    private static void ShowNotification(IToastNotification toastNotification, bool isSuccess, string message)
    {
        if (isSuccess)
            NotificationHelper.ShowSuccess(toastNotification, message);
        else
            NotificationHelper.ShowError(toastNotification, message);
    }
}
