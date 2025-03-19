using Entities.Dtos;
using FluentValidation;

namespace Business.Modules.Abouts.Validations;

public class UpdateAboutValidator : AbstractValidator<UpdateAboutDto>
{
    public UpdateAboutValidator()
    {
        RuleFor(a => a.Description)
            .NotEmpty()
            .WithMessage("Hakkımda içeriği boş olamaz.");
    }
}