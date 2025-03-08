using AutoMapper;
using Business.Abstract;
using Business.Concrete.Base;
using Business.Helpers.Validations;
using Core.Aspects.Autofac.Caching;
using DataAccess.Abstract;
using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;

namespace Business.Concrete;

public class PortfolioManager : BaseManager, IPortfolioService
{
    public PortfolioManager(IValidationHelper validationHelper, IRepository repository, IMapper mapper) : base(validationHelper, repository, mapper)
    {
    }

    [CacheAspect]
    public async Task<IDataResult<IList<GetAllPortfolioDto>>> GetAllAsync()
    {
        IList<Entities.Concrete.Portfolio> portfolios = await Repository.GetRepository<Entities.Concrete.Portfolio>().GetAllAsync();

        IList<GetAllPortfolioDto> getAllPortfolioDtos = Mapper.Map<IList<GetAllPortfolioDto>>(portfolios);
        return new DataResult<IList<GetAllPortfolioDto>>(ResultStatus.Success, getAllPortfolioDtos);
    }
}