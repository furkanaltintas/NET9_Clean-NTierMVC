using AutoMapper;
using Business.Helpers.Validations;
using DataAccess.Abstract;

namespace Business.Concrete.Base;

public class BaseManager
{
    public BaseManager(IValidationHelper validationHelper, IRepository repository, IMapper mapper)
    {
        ValidationHelper = validationHelper;
        Repository = repository;
        Mapper = mapper;
    }

    protected IValidationHelper ValidationHelper { get; }
    protected IRepository Repository { get; }
    protected IMapper Mapper { get; }
}