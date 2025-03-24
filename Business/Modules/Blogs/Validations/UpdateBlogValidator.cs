using Business.Constants;
using Business.Modules.Blogs.Constants;
using Core.Helpers.Images.Valid;
using Entities.Dtos;
using FluentValidation;

namespace Business.Modules.Blogs.Validations;

public class UpdateBlogValidator : AbstractValidator<UpdateBlogDto>
{
    public UpdateBlogValidator()
    {
        RuleFor(b => b.Title)
            .NotEmpty().WithMessage(BlogsMessages.TitleRequired)
            .Length(3, 100).WithMessage(BlogsMessages.TitleLength);

        RuleFor(b => b.Content)
            .NotEmpty().WithMessage(BlogsMessages.ContentRequired)
            .Length(3, 2000).WithMessage(BlogsMessages.ContentLength);

        RuleFor(b => b.PublishDate)
            .NotEmpty().WithMessage("Yayın tarihi zorunludur.")
            .Must(date => date > DateTime.Now).WithMessage("Yayın tarihi bugünden büyük olmalıdır.");

        RuleFor(b => b.Photo)
            .NotEmpty().WithMessage(Messages.PhotoRequired)
            .Must(IsValidImageAndFileSize.IsValidImageFile).WithMessage(Messages.InvalidImageFile)
            .Must(IsValidImageAndFileSize.IsValidFileSize).WithMessage(Messages.InvalidFileSize);
    }
}
