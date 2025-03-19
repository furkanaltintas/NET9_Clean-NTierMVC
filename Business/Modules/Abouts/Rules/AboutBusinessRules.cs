using Business.Constants;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;

namespace Business.Modules.Abouts.Rules;

public class AboutBusinessRules : BaseBusinessRules
{
    private readonly IRepository _repository;

    public AboutBusinessRules(IRepository repository)
    {
        _repository = repository;
    }

    public async Task<IResult> CheckIfAboutExists()
    {
        return await _repository.GetRepository<About>().AnyAsync()
            ? new Result(ResultStatus.Success)
            : new Result(ResultStatus.Error, Messages.InvalidValue("About"));
    }
}