using Business.Constants;
using Business.Modules.Portfolios.Constants;
using Core.Helpers.Images.Valid;
using Entities.Dtos;
using FluentValidation;

namespace Business.Modules.Portfolios.Validations
{
    public class UpdatePortfolioValidator : AbstractValidator<UpdatePortfolioDto>
    {
        public UpdatePortfolioValidator()
        {
            RuleFor(p => p.Title)
                .NotEmpty().WithMessage(PortfoliosMessages.TitleRequired)
                .MaximumLength(100).WithMessage(PortfoliosMessages.TitleLength);

            RuleFor(b => b.Photo)
                .NotEmpty().WithMessage(Messages.PhotoRequired)
                .Must(IsValidImageAndFileSize.IsValidImageFile).WithMessage(Messages.InvalidImageFile)
                .Must(IsValidImageAndFileSize.IsValidFileSize).WithMessage(Messages.InvalidFileSize);
        }
    }
}