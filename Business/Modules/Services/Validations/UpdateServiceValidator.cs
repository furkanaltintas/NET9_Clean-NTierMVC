using Business.Modules.Services.Constants;
using Entities.Dtos;
using FluentValidation;

namespace Business.Modules.Services.Validations;

public class UpdateServiceValidator : AbstractValidator<UpdateServiceDto>
{
    public UpdateServiceValidator()
    {
        RuleFor(s => s.Name)
            .NotEmpty().WithMessage(ServicesMessages.NameRequired)
            .MaximumLength(100).WithMessage(ServicesMessages.NameLength);

        RuleFor(s => s.Description)
            .NotEmpty().WithMessage(ServicesMessages.DescriptionRequired)
            .MaximumLength(500).WithMessage(ServicesMessages.DescriptionLength);

        RuleFor(s => s.Icon)
            .NotEmpty().WithMessage(ServicesMessages.IconRequired)
            .MaximumLength(100).WithMessage(ServicesMessages.IconLength);
    }
}