using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class BlogValidator : AbstractValidator<Blog>
    {
        public BlogValidator()
        {
            RuleFor(b => b.Title)
                .NotEmpty().WithMessage("Başlık alanı zorunludur.")
                .Length(3, 75).WithMessage("Başlık en az 3, en fazla 75 karakter olmalıdır.");

            RuleFor(b => b.Slug)
                .NotEmpty().WithMessage("Slug alanı zorunludur.")
                .Length(3, 100).WithMessage("Slug en az 3, en fazla 100 karakter olmalıdır.");

            RuleFor(b => b.Content)
                .NotEmpty().WithMessage("İçerik alanı boş olamaz.")
                .Length(3, 5000).WithMessage("İçerik en az 3, en fazla 5000 karakter olmalıdır.");

            RuleFor(b => b.Image)
                .NotEmpty().WithMessage("Blog görseli zorunludur.")
                .Must(IsValidImage).WithMessage("Geçerli bir resim URL'si giriniz.");

            RuleFor(b => b.PublishDate)
                .NotEmpty().WithMessage("Yayın tarihi zorunludur.")
                .Must(date => date > DateTime.Now).WithMessage("Yayın tarihi bugünden büyük olmalıdır.");
        }

        private bool IsValidImage(string imageUrl)
        {
            if (string.IsNullOrWhiteSpace(imageUrl))
                return false;

            string[] validExtensions = { ".jpg", ".jpeg", ".png", ".gif", ".webp" };
            return validExtensions.Any(ext => imageUrl.EndsWith(ext, StringComparison.OrdinalIgnoreCase));
        }
    }
}
