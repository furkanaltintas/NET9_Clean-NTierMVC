using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Business.Utilities;

public static class SlugHelper
{
    public static string GenerateSlug(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            return string.Empty;

        // Normalize string
        string normalized = title.ToLower().Normalize(NormalizationForm.FormD);

        // Remove diacritics (accents)
        StringBuilder stringBuilder = new StringBuilder();
        foreach (char c in normalized)
        {
            if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                stringBuilder.Append(c);
        }

        string slug = stringBuilder.ToString();
        slug = Regex.Replace(slug, @"[^a-z0-9\s-]", "");
        slug = Regex.Replace(slug, @"\s+", " ").Trim();
        slug = slug.Replace(" ", "-");

        return slug;
    }
}