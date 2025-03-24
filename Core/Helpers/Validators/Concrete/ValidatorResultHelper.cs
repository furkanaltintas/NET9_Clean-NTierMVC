using Core.Entities.Abstract;
using Core.Entities.Concrete;
using FluentValidation;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;

namespace Core.Helpers.Validators.Concrete;

public static class ValidatorResultHelper
{
    public static async Task<IResult> ValidatorResult<TEntity>(IValidator<TEntity> validator, TEntity entity)
        where TEntity : IDto
    {
        List<ValidationError> errors = await ValidatorHelper.ValidateAsync(validator, entity);
        if (errors.Any()) return new Result(ResultStatus.Validation, message: ErrorMessages(errors), validationErrors: errors);
        return new Result(ResultStatus.Success);
    }

    private static string ErrorMessages(List<ValidationError> validationErrors) => string.Join("<br>", validationErrors.Select(v => v.Message));
}