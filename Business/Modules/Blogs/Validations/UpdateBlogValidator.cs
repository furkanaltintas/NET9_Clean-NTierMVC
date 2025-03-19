using Entities.Dtos;
using FluentValidation;

namespace Business.Modules.Blogs.Validations;

public class UpdateBlogValidator : AbstractValidator<UpdateBlogDto>
{
    public UpdateBlogValidator()
    {
        RuleFor(b => b.Title)
            .NotEmpty().WithMessage("Başlık alanı zorunludur.")
            .Length(3, 75).WithMessage("Başlık en az 3, en fazla 75 karakter olmalıdır.");

        RuleFor(b => b.Content)
            .NotEmpty().WithMessage("İçerik alanı boş olamaz.")
            .Length(3, 5000).WithMessage("İçerik en az 3, en fazla 5000 karakter olmalıdır.");

        RuleFor(b => b.PublishDate)
            .NotEmpty().WithMessage("Yayın tarihi zorunludur.")
            .Must(date => date > DateTime.Now).WithMessage("Yayın tarihi bugünden büyük olmalıdır.");
    }
}
