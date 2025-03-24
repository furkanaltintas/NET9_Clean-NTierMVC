using Business.Constants;
using Business.Modules.Educations.Constants;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;

namespace Business.Modules.Educations.Rules;

public class EducationBusinessRules(IRepository repository) : BaseBusinessRules
{
    public async Task<IResult> CheckIfEducationExistsAsync(int id)
    {
        return await repository.GetRepository<Education>().AnyAsync(e => e.Id == id)
            ? new Result(ResultStatus.Success)
            : new Result(ResultStatus.Error, Messages.InvalidValue(EducationsMessages.Education));
    }
}