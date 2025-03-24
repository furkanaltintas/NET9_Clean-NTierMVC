namespace Business.Constants;

public static class Messages
{
    public const string PhotoRequired = "A blog image is required.";
    public const string InvalidImageFile = "Please upload a valid image file (jpg, png, gif, webp).";
    public const string InvalidFileSize = "The file size must not exceed 2MB.";





    public static string Created(string entityName) => $"{entityName} has been successfully created.";
    public static string Updated(string entityName) => $"{entityName} has been successfully updated.";
    public static string Deleted(string entityName) => $"{entityName} has been successfully deleted.";
    public static string NotFound(string entityName) => $"{entityName} not found.";
    public static string AlreadyExists(string entityName) => $"{entityName} already exists.";
    public static string RequiredField(string fieldName) => $"{fieldName} is required.";
    public static string InvalidValue(string fieldName) => $"{fieldName} is invalid.";

    public static string UnauthorizedAccess = "You are not authorized to perform this action.";
}




/* MESSAGES
 
 
 

 
// ✅ Genel Mesajlar
public const string AboutCreated = "About has been successfully created.";
public const string AboutUpdated = "About has been successfully updated.";
public const string AboutDeleted = "About has been successfully deleted.";

// ❌ Hata Mesajları
public const string AboutNameExists = "About name already exists.";
public const string AboutNotFound = "About not found.";
public const string AboutNameRequired = "About name is required.";
public const string AboutDescriptionRequired = "About description is required.";
public const string AboutNameLength = "About name must be between 2 and 100 characters.";
public const string AboutDescriptionLength = "About description must be at most 500 characters.";
public const string AboutStatusInvalid = "Invalid about status.";

// ⚠️ Yetkilendirme Mesajları
public const string UnauthorizedAccess = "You are not authorized to perform this action.";
public const string PermissionDenied = "You do not have permission to manage abouts.";

// 📌 Cache & Sistem Mesajları
public const string AboutsCacheRefreshed = "Abouts cache has been refreshed.";
public const string AboutsCacheCleared = "Abouts cache has been cleared.";

// 🔍 Arama ve Filtreleme
public const string NoAboutsAvailable = "No abouts available.";
public const string SearchNoResults = "No abouts found matching the search criteria.";
 
 
 
 
 
 
 
 */