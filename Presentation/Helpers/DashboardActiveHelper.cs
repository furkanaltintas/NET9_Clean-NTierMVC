namespace Presentation.Helpers;

public static class DashboardActiveHelper
{
    public static string Active(string controllerName, string[] pathName)
    {
        var exists = pathName.Any(p => p.Contains(controllerName));
        return exists ? "active" : "";
    }
}