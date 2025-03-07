using Portfolio.Core.Utilities.Results.Abstract;

namespace Business.Helpers.Validations;

public interface IAboutValidationHelper
{
    Task<IResult> CheckIfAboutExists();
}