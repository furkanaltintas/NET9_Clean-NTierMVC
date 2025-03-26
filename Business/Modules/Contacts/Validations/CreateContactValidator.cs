using Business.Modules.Contacts.Constants;
using Entities.Dtos;
using FluentValidation;

namespace Business.Modules.Contacts.Validations;

public class CreateContactValidator : AbstractValidator<CreateContactDto>
{
    public CreateContactValidator()
    {
        RuleFor(c => c.FullName)
            .NotEmpty().WithMessage(ContactsMessages.FullNameRequired)
            .MaximumLength(100).WithMessage(ContactsMessages.FullNameLength);

        RuleFor(c => c.Email)
            .NotEmpty().WithMessage(ContactsMessages.EmailRequired)
            .EmailAddress().WithMessage(ContactsMessages.EmailInvalid)
            .MaximumLength(100).WithMessage(ContactsMessages.EmailLength);

        RuleFor(c => c.Message)
            .NotEmpty().WithMessage(ContactsMessages.MessageRequired)
            .MaximumLength(1000).WithMessage(ContactsMessages.MessageLength);

        RuleFor(c => c.CaptchaCode)
            .NotEmpty().WithMessage(ContactsMessages.CaptchaCodeRequired);
    }
}