namespace Presentation.Helpers;

public static class DashboardBreadcrumbHelper
{
    public static string GetTranslatedControllerName(string controller)
    {
        var newControllerName = char.ToUpper(controller[0]) + controller.Substring(1).ToLower();
        string controllerName = GetControllerName(newControllerName); // About

        return controllerName;
    }

    public static string GetTranslatedActionName(string action)
    {
        if (action == "Index" || action == "index")
            return "İşlemler";

        var breadcrumbs = new Dictionary<string, string>
            {
                { "Add", "Kaydetme" },
                { "Update", "Güncelleme" },
                { "Delete", "Silme" },
                { "Detail", "Detay" }
            };

        return breadcrumbs.TryGetValue(action, out string title) ? title : "Bilinmeyen Sayfa";
    }


    private static string GetControllerName(string controllerName)
    {
        switch (controllerName)
        {
            case "About":
                return "Hakkımda Yönetimi";
            case "Blog":
                return "Blog Yönetimi";
            case "Certificate":
                return "Sertifika Yönetimi";
            case "Education":
                return "Eğitim Yönetimi";
            case "Experience":
                return "Deneyim Yönetimi";
            case "Home":
                return "Yönetim";
            case "Portfolio":
                return "Portfolyo Yönetimi";
            case "Service":
                return "Servis Yönetimi";
            case "Skill":
                return "Yetenek Yönetimi";
            case "SocialMedia":
                return "Sosyal Medya Yönetimi";
            case "User":
                return "Profil Yönetimi";
            default:
                return controllerName;
        }
    }
}