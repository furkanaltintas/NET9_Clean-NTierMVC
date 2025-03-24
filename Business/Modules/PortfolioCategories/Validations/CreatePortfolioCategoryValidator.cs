using Business.Modules.PortfolioCategories.Constants;
using Entities.Dtos;
using FluentValidation;

namespace Business.Modules.PortfolioCategories.Validations;

public class CreatePortfolioCategoryValidator : AbstractValidator<CreatePortfolioCategoryDto>
{
    public CreatePortfolioCategoryValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().WithMessage(PortfolioCategoriesMessages.NameRequired)
            .MaximumLength(25).WithMessage(PortfolioCategoriesMessages.NameLength);
    }
}