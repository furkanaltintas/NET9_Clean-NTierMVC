using Business.Constants;
using DataAccess.Abstract;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;
using PortfolioApp.Entities.Concrete;
using System.Threading.Tasks;

namespace Business.Helpers.Validations;

public class AboutValidationHelper : IAboutValidationHelper
{
    private readonly IRepository _repository;

    public AboutValidationHelper(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<IResult> CheckIfAboutExists()
    {
        return await _repository.GetRepository<About>().AnyAsync()
            ? new Result(ResultStatus.Success)
            : new Result(ResultStatus.Error, Messages.NameAlreadyExists);
    }
}