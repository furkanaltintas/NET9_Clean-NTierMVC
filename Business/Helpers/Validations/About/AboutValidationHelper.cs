using Business.Constants;
using DataAccess.Abstract;
using Entities.Concrete;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;

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
            : new Result(ResultStatus.Error, "Sistemde hakkımda kısmı bulunmamaktadır.");
    }
}