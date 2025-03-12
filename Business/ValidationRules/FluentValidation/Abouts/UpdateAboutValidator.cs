using Entities.Dtos;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation.Abouts;

public class UpdateAboutValidator : AbstractValidator<UpdateAboutDto>
{
    public UpdateAboutValidator()
    {
        RuleFor(a => a.Description)
            .NotEmpty()
            .WithMessage("Hakkımda içeriği boş olamaz.");
    }
}