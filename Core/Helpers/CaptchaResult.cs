namespace Core.Helpers;

public class CaptchaResult
{
    public string CaptchaCode { get; set; }
    public byte[] CaptchaByteData { get; set; }
    public string CaptchaBase64Data => Convert.ToBase64String(CaptchaByteData);
    public DateTime TimeStamp { get; set; }
}