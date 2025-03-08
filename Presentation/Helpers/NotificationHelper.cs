using NToastNotify;

namespace Presentation.Helpers;

public static class NotificationHelper
{
    public static void ShowSuccess(IToastNotification toast, string message, string title = "Başarılı İşlem!")
    {
        toast.AddSuccessToastMessage(message, new ToastrOptions { Title = title });
    }

    public static void ShowError(IToastNotification toast, string message, string title = "Hata!")
    {
        toast.AddErrorToastMessage(message, new ToastrOptions { Title = title });
    }

    public static void ShowWarning(IToastNotification toast, string message, string title = "Dikkat!")
    {
        toast.AddWarningToastMessage(message, new ToastrOptions { Title = title });
    }

    public static void ShowInfo(IToastNotification toast, string message, string title = "Bilgilendirme")
    {
        toast.AddInfoToastMessage(message, new ToastrOptions { Title = title });
    }
}
