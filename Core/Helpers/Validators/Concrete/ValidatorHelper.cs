using Core.Entities.Abstract;
using Core.Entities.Concrete;
using FluentValidation;
using FluentValidation.Results;

namespace Core.Helpers.Validators.Concrete;

public static class ValidatorHelper
{
    // eski hali string döndürüyordu
    public static async Task<List<ValidationError>> ValidateAsync<TEntity>(IValidator validator, TEntity entity)
        where TEntity : IDto
    {
        ValidationContext<TEntity> validationContext = new(entity);
        return Errors(
            await validator.ValidateAsync(validationContext)
            );
    }

    public static List<ValidationError> Validate(IValidator validator, object entity)
    {
        ValidationContext<object> validationContext = new(entity);
        return Errors(
            validator.Validate(validationContext)
            );
    }

    private static List<ValidationError> Errors(ValidationResult validationResult)
    {
        if (!validationResult.IsValid)
            return validationResult.Errors.Select(e => new ValidationError(e.PropertyName, e.ErrorMessage)).ToList();
        else
            return new List<ValidationError>();
    }
}