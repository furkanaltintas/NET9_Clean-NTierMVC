﻿using Business.Modules.Experiences.Constants;
using Entities.Dtos;
using FluentValidation;

namespace Business.Modules.Experiences.Validations;

public class UpdateExperienceValidator : AbstractValidator<UpdateExperienceDto>
{
    public UpdateExperienceValidator()
    {
        RuleFor(e => e.Title)
    .NotEmpty().WithMessage(ExperiencesMessages.TitleRequired)
    .MaximumLength(75).WithMessage(ExperiencesMessages.TitleLength);

        RuleFor(e => e.Company)
            .NotEmpty().WithMessage(ExperiencesMessages.CompanyRequired)
            .MaximumLength(100).WithMessage(ExperiencesMessages.CompanyLength);

        RuleFor(e => e.Description)
            .NotEmpty().WithMessage(ExperiencesMessages.DescriptionRequired)
            .MaximumLength(1000).WithMessage(ExperiencesMessages.DescriptionLength);

        RuleFor(e => e.Location)
            .NotEmpty().WithMessage(ExperiencesMessages.LocationRequired)
            .MaximumLength(50).WithMessage(ExperiencesMessages.LocationLength);

        RuleFor(e => e.TypeOfEmploymentId)
            .Must(id => id == null || id > 0)
            .WithMessage(ExperiencesMessages.TypeOfEmploymentInvalid);
    }
}