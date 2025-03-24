using Business.Constants;
using Business.Modules.Testimonials.Constants;
using Core.Helpers.Images.Valid;
using Entities.Dtos;
using FluentValidation;

namespace Business.Modules.Testimonials.Validations;

public class UpdateTestimonialValidator : AbstractValidator<UpdateTestimonialDto>
{
    public UpdateTestimonialValidator()
    {
        RuleFor(t => t.FullName)
            .NotEmpty().WithMessage(TestimonialsMessages.FullNameRequired)
            .MaximumLength(75).WithMessage(TestimonialsMessages.FullNameLength);

        RuleFor(t => t.Message)
            .NotEmpty().WithMessage(TestimonialsMessages.MessageRequired)
            .MaximumLength(100).WithMessage(TestimonialsMessages.MessageLength);

        RuleFor(b => b.Photo)
            .NotEmpty().WithMessage(Messages.PhotoRequired)
            .Must(IsValidImageAndFileSize.IsValidImageFile).WithMessage(Messages.InvalidImageFile)
            .Must(IsValidImageAndFileSize.IsValidFileSize).WithMessage(Messages.InvalidFileSize);
    }
}