using Entities.Dtos;
using FluentValidation;

namespace Business.Modules.Auths.Validations;

public class LoginUserValidator : AbstractValidator<GetUserLoginDto>
{
    public LoginUserValidator()
    {
        RuleFor(u => u.Email).NotEmpty();
        RuleFor(u => u.Password).NotEmpty();
    }
}