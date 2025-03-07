using DataAccess.Abstract;

namespace Business.Helpers.Validations;

public class ValidationHelper : IValidationHelper
{
    private readonly IAboutValidationHelper _aboutValidationHelper;

    public ValidationHelper(IRepository repository)
    {
        _aboutValidationHelper = new AboutValidationHelper(repository);
    }

    public IAboutValidationHelper AboutValidationHelper => _aboutValidationHelper;
}