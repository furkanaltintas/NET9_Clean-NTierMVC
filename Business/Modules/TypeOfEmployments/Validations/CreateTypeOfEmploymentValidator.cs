using Business.Modules.TypeOfEmployments.Constants;
using Entities.Dtos;
using FluentValidation;

namespace Business.Modules.TypeOfEmployments.Validations;

class CreateTypeOfEmploymentValidator : AbstractValidator<CreateTypeOfEmploymentDto>
{
    public CreateTypeOfEmploymentValidator()
    {
        RuleFor(t => t.Name)
            .NotEmpty().WithMessage(TypeOfEmploymentsMessages.NameRequired)
            .MaximumLength(30).WithMessage(TypeOfEmploymentsMessages.NameLength);
    }
}