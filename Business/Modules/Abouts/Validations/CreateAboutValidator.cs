using Entities.Dtos;
using FluentValidation;

namespace Business.Modules.Abouts.Validations;

public class CreateAboutValidator : AbstractValidator<CreateAboutDto>
{
    public CreateAboutValidator()
    {
        RuleFor(a => a.Description)
            .NotEmpty()
            .WithMessage("Hakkımda içeriği boş olamaz.");
    }
}