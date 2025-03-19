namespace Presentation.Helpers;

public static class DashboardActiveHelper
{
    public static string Active(string controllerName, string[] pathName)
    {
        var exists = pathName.Where(p => p == controllerName).Any();
        return exists ? "active" : "";
    }
}