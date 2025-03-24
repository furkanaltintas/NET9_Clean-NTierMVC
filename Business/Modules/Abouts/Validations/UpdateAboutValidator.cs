using Business.Modules.Abouts.Constants;
using Entities.Dtos;
using FluentValidation;

namespace Business.Modules.Abouts.Validations;

public class UpdateAboutValidator : AbstractValidator<UpdateAboutDto>
{
    public UpdateAboutValidator()
    {
        RuleFor(a => a.Description)
            .NotEmpty()
            .WithMessage(AboutsMessages.AboutMeContentCannotBeEmpty);

        RuleFor(a => a.Description).MaximumLength(2000).WithMessage(AboutsMessages.MaximumLength);
    }
}