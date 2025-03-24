using Business.Modules.SocialMedias.Constants;
using Entities.Dtos;
using FluentValidation;

namespace Business.Modules.SocialMedias.Validations;

public class UpdateSocialMediaValidator : AbstractValidator<UpdateSocialMediaIconDto>
{
    public UpdateSocialMediaValidator()
    {
        RuleFor(s => s.Name)
            .NotEmpty().WithMessage(SocialMediasMessages.NameRequired)
            .MaximumLength(30).WithMessage(SocialMediasMessages.NameLength);

        RuleFor(s => s.Icon)
            .NotEmpty().WithMessage(SocialMediasMessages.IconRequired)
            .MaximumLength(20).WithMessage(SocialMediasMessages.IconLength);

        RuleFor(s => s.Link)
            .NotEmpty().WithMessage(SocialMediasMessages.LinkRequired)
            .MaximumLength(100).WithMessage(SocialMediasMessages.LinkLength);
    }
}