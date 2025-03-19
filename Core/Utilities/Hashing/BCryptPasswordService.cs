namespace Core.Utilities.Hashing;

public static class BCryptPasswordService
{
    public static string HashPassword(string password) =>
        BCrypt.Net.BCrypt.HashPassword(password);

    public static bool VerifyPassword(string inputPassword, string hashedPassword) =>
        BCrypt.Net.BCrypt.Verify(inputPassword, hashedPassword);
}