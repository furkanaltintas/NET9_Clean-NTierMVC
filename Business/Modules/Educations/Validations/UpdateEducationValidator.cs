using Business.Modules.Educations.Constants;
using Entities.Dtos;
using FluentValidation;

namespace Business.Modules.Educations.Validations;

public class UpdateEducationValidator : AbstractValidator<UpdateEducationDto>
{
    public UpdateEducationValidator()
    {
        RuleFor(e => e.Title)
            .MaximumLength(100).WithMessage(EducationsMessages.TitleLength);

        RuleFor(e => e.Degree)
            .MaximumLength(50).WithMessage(EducationsMessages.DegreeLength);

        RuleFor(e => e.Department)
            .MaximumLength(100).WithMessage(EducationsMessages.DepartmentLength);

        RuleFor(e => e.Description)
            .MaximumLength(1000).WithMessage(EducationsMessages.DescriptionLength);
    }
}