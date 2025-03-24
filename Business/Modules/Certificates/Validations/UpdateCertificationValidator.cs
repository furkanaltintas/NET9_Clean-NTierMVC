using Business.Constants;
using Business.Modules.Certificates.Constants;
using Core.Helpers.Images.Valid;
using Entities.Dtos;
using FluentValidation;

namespace Business.Modules.Certificates.Validations;

public class UpdateCertificationValidator : AbstractValidator<UpdateCertificateDto>
{
    public UpdateCertificationValidator()
    {
        RuleFor(c => c.Title)
            .NotEmpty().WithMessage(CertificatesMessages.TitleRequired)
            .MaximumLength(200).WithMessage(CertificatesMessages.TitleLength);

        RuleFor(b => b.Photo)
            .NotEmpty().WithMessage(Messages.PhotoRequired)
            .Must(IsValidImageAndFileSize.IsValidImageFile).WithMessage(Messages.InvalidImageFile)
            .Must(IsValidImageAndFileSize.IsValidFileSize).WithMessage(Messages.InvalidFileSize);
    }
}