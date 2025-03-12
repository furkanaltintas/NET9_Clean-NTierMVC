using Entities.Dtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.Contacts;

public class CreateContactValidator : AbstractValidator<CreateContactDto>
{
    public CreateContactValidator()
    {
        RuleFor(x => x.FullName).NotEmpty().WithMessage("Ad Soyad alanı boş geçilemez");
        RuleFor(x => x.Email).NotEmpty().WithMessage("E-Posta alanı boş geçilemez");
        RuleFor(x => x.Message).NotEmpty().WithMessage("Mesaj alanı boş bırakılamaz");
    }
}