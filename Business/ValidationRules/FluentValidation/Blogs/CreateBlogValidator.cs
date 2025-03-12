using Entities.Dtos;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace Business.ValidationRules.FluentValidation.Blogs;

class CreateBlogValidator : AbstractValidator<CreateBlogDto>
{
    private readonly string[] _validExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
    private const int MaxFileSizeInBytes = 2 * 1024 * 1024; // 2MB

    public CreateBlogValidator()
    {
        RuleFor(b => b.Title)
            .NotEmpty().WithMessage("Başlık alanı zorunludur.")
            .Length(3, 75).WithMessage("Başlık en az 3, en fazla 75 karakter olmalıdır.");

        RuleFor(b => b.Content)
            .NotEmpty().WithMessage("İçerik alanı boş olamaz.")
            .Length(3, 5000).WithMessage("İçerik en az 3, en fazla 5000 karakter olmalıdır.");

        RuleFor(b => b.Photo)
            .NotEmpty().WithMessage("Blog görseli zorunludur.")
            .Must(IsValidImageFile).WithMessage("Geçerli bir resim dosyası yükleyiniz (jpg, png, gif, webp).")
            .Must(IsValidFileSize).WithMessage("Dosya boyutu en fazla 2MB olmalıdır");

        RuleFor(b => b.PublishDate)
            .NotEmpty().WithMessage("Yayın tarihi zorunludur.")
            .Must(date => date > DateTime.Now).WithMessage("Yayın tarihi bugünden büyük olmalıdır.");
    }

    private bool IsValidImageFile(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return false;

        string extensions = Path.GetExtension(file.FileName);
        return _validExtensions.Contains(extensions, StringComparer.OrdinalIgnoreCase);
    }

    private bool IsValidFileSize(IFormFile file) =>
        file.Length <= MaxFileSizeInBytes;
}