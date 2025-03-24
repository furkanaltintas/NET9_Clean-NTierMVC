using Business.Modules.Educations.Constants;
using Entities.Dtos;
using FluentValidation;

namespace Business.Modules.Educations.Validations;

public class CreateEducationValidator : AbstractValidator<CreateEducationDto>
{
    public CreateEducationValidator()
    {
        RuleFor(e => e.Title)
            .NotEmpty().WithMessage(EducationsMessages.TitleRequired)
            .MaximumLength(100).WithMessage(EducationsMessages.TitleLength);

        RuleFor(e => e.Degree)
            .NotEmpty().WithMessage(EducationsMessages.DegreeRequired)
            .MaximumLength(50).WithMessage(EducationsMessages.DegreeLength);

        RuleFor(e => e.Department)
            .NotEmpty().WithMessage(EducationsMessages.DepartmentRequired)
            .MaximumLength(100).WithMessage(EducationsMessages.DepartmentLength);

        RuleFor(e => e.Description)
            .NotEmpty().WithMessage(EducationsMessages.DescriptionRequired)
            .MaximumLength(1000).WithMessage(EducationsMessages.DescriptionLength);
    }
}