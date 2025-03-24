namespace Business.Modules.Blogs.Constants;

public static class BlogsMessages
{
    public const string Blog = "Blog";

    // VALIDATOR
    public const string TitleRequired = "The title field is required.";
    public const string TitleLength = "The title must be between 3 and 100 characters long.";
    public const string ContentRequired = "The content field cannot be empty.";
    public const string ContentLength = "The content must be between 3 and 2000 characters long.";
    public const string PublishDateRequired = "The publish date is required.";
    public const string PublishDateMustBeFuture = "The publish date must be in the future.";
}