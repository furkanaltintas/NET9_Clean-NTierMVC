namespace Presentation.Helpers;

public static class DashboardBreadcrumbHelper
{
    #region Eski Versiyon
    // Blog Managemenet -> Transactions -> Blog Add

    //public static string GetTranslatedControllerName(string controller)
    //{
    //    string controllerName = GetControllerName(CapitalizeFirstCharacter(controller)); // About
    //    return controllerName;
    //}

    //public static string GetTranslatedActionName(string action)
    //{
    //    if (action == "Index" || action == "index")
    //        return "Transactions";

    //    var breadcrumbs = new Dictionary<string, string>
    //        {
    //            { "Add", "Add" },
    //            { "Update", "Update" },
    //            { "Delete", "Delete" },
    //            { "Detail", "Detail" }
    //        }; // Türkçeleştirme için.

    //    return breadcrumbs.TryGetValue(action, out string title) ? title : "Not Found???";
    //}


    //private static string GetControllerName(string controllerName)
    //{
    //    switch (controllerName)
    //    {
    //        case "About":
    //            return "About Me Management";
    //        case "Blog":
    //            return "Blog Management";
    //        case "Certificate":
    //            return "Certificate Management";
    //        case "Education":
    //            return "Education Management";
    //        case "Experience":
    //            return "Experience Management";
    //        case "Home":
    //            return "Management";
    //        case "Portfolio":
    //            return "Portfolio Management";
    //        case "Service":
    //            return "Service Management";
    //        case "Skill":
    //            return "Skill Management";
    //        case "SocialMedia":
    //            return "SocialMedia Management";
    //        case "User":
    //            return "Profile Management";
    //        default:
    //            return controllerName;
    //    }
    //}
    #endregion


    // Güncel Hali
    public static string PageTitle(string controllerName, string actionName)
    {
        var newControllerName = CapitalizeFirstCharacter(controllerName);

        if (actionName == "Index" || actionName == "index")
            return $"{newControllerName} Management";

        var newActionName = CapitalizeFirstCharacter(actionName);
        return $"{newControllerName} {newActionName}";
    }


    public static string CapitalizeFirstCharacter(string action)
    {
        switch (action)
        {
            case "portfoliocategory":
                action = "portfolio category";
                break;
            case "typeofemployment":
                action = "type of employment";
                break;
            case "socialmedia":
                action = "social media";
                break;
            default:
                break;
        }


        return char
               .ToUpper(action[0]) + action
                                     .Substring(1)
                                     .Replace("i", "ı")
                                     .ToLower();
    }
}