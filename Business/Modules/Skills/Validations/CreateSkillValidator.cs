using Business.Modules.Skills.Constants;
using Entities.Dtos;
using FluentValidation;

namespace Business.Modules.Skills.Validations;

public class CreateSkillValidator : AbstractValidator<CreateSkillDto>
{
    public CreateSkillValidator()
    {
        RuleFor(s => s.Name)
            .NotEmpty().WithMessage(SkillsMessages.NameRequired)
            .MaximumLength(50).WithMessage(SkillsMessages.NameLength);

        RuleFor(s => s.Point)
            .NotEmpty().WithMessage(SkillsMessages.PointRequired)
            .InclusiveBetween(0, 100).WithMessage(SkillsMessages.PointRange);
    }
}