using FluentValidation;
using PortfolioApp.Entities.Concrete;

namespace Business.ValidationRules.FluentValidation;

public class AboutValidator : AbstractValidator<About>
{
    public AboutValidator()
    {
        RuleFor(a => a.Description)
            .NotEmpty()
            .WithMessage("Hakkımda içeriği boş olamaz.");
    }
}