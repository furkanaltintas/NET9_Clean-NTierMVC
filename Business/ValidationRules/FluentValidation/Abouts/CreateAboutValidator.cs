using Entities.Dtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.Abouts;

public class CreateAboutValidator : AbstractValidator<CreateAboutDto>
{
    public CreateAboutValidator()
    {
        RuleFor(a => a.Description)
            .NotEmpty()
            .WithMessage("Hakkımda içeriği boş olamaz.");
    }
}