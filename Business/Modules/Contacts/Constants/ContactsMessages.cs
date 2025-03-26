namespace Business.Modules.Contacts.Constants;

public static class ContactsMessages
{
    public const string Contact = "Contact";

    public const string MessageSent = "Your message has been delivered.";


    // Valid
    public const string FullNameRequired = "The full name is required";
    public const string FullNameLength = "The full name must not exceed 100 characters.";
    public const string EmailRequired = "The email address is required.";
    public const string EmailInvalid = "Please provide a valid email address.";
    public const string EmailLength = "The email address must not exceed 100 characters.";
    public const string MessageRequired = "The message field is required.";
    public const string MessageLength = "The message must not exceed 1000 characters.";
    public const string CaptchaCodeRequired = "The captcha code is required.";
}