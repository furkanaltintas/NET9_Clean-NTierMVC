using FluentValidation;

namespace Core.Helpers.Validators.Abstract;

public interface IValidatorGetFactory
{
    IValidator<T> GetValidator<T>();
}
