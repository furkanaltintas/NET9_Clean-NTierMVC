using NToastNotify;

namespace Presentation.Helpers;

public static class NotificationHelper
{
    public static void ShowSuccess(IToastNotification toast, string message, string title = "Successful Transaction!")
    {
        toast.AddSuccessToastMessage(message, new ToastrOptions { Title = title });
    }

    public static void ShowError(IToastNotification toast, string message, string title = "Error!")
    {
        toast.AddErrorToastMessage(message, new ToastrOptions { Title = title });
    }

    public static void ShowWarning(IToastNotification toast, string message, string title = "Warning!")
    {
        toast.AddWarningToastMessage(message, new ToastrOptions { Title = title });
    }

    public static void ShowInfo(IToastNotification toast, string message, string title = "Information")
    {
        toast.AddInfoToastMessage(message, new ToastrOptions { Title = title });
    }

    public static void ShowValidation(IToastNotification toast, string message, string title = "Validation Error!")
    {
        toast.AddAlertToastMessage(message, new ToastrOptions { Title = title });
    }
}
