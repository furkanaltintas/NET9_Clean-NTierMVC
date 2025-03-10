using AutoMapper;
using Business.Abstract;
using Business.Concrete.Base;
using Business.Constants;
using Business.Helpers.Validations;
using Core.Aspects.Autofac.Caching;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;

namespace Business.Concrete;

public class EducationManager : BaseManager, IEducationService
{
    public EducationManager(IValidationHelper validationHelper, IRepository repository, IMapper mapper) : base(validationHelper, repository, mapper)
    {
    }


    [CacheRemoveAspect("IEducationService.Get")]
    public async Task<IResult> AddEducationAsync(CreateEducationDto createEducationDto)
    {
        Education education = Mapper.Map<Education>(createEducationDto);
        await Repository.GetRepository<Education>().AddAsync(education);
        return new Result(ResultStatus.Success, Messages.Added);
    }


    [CacheRemoveAspect("IEducationService.Get")]
    public async Task<IResult> DeleteEducationAsync(int id)
    {
        Education education = await Repository.GetRepository<Education>().GetAsync(e => e.Id == id);

        if (education == null)
            return new Result(ResultStatus.Error, "Sistemde böyle bir eğitim bilgisi bulunmamaktadır.");

        await Repository.GetRepository<Education>().HardDeleteAsync(education);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, "Eğitim bilgisi sistemden başarıyla silinmiştir");
    }


    [CacheAspect]
    public async Task<IDataResult<IList<GetAllEducationDto>>> GetAllAsync()
    {
        IList<Education> educations = await Repository.GetRepository<Education>().GetAllAsync(orderBy: e => e.OrderByDescending(e => e.StartDate));

        IList<GetAllEducationDto> getAllEducationDtos = Mapper.Map<IList<GetAllEducationDto>>(educations);
        return new DataResult<IList<GetAllEducationDto>>(ResultStatus.Success, getAllEducationDtos);
    }

    [CacheAspect]
    public async Task<IDataResult<GetEducationDto>> GetEducationAsync(int id)
    {
        Education education = await Repository.GetRepository<Education>().GetAsync(e => e.Id == id);

        if (education == null)
            return new DataResult<GetEducationDto>(ResultStatus.Error, "Sistemde böyle bir eğitim bilgisi bulunmamaktadır.");

        GetEducationDto getEducationDto = Mapper.Map<GetEducationDto>(education);
        return new DataResult<GetEducationDto>(ResultStatus.Success,  getEducationDto);
    }


    [CacheAspect]
    public async Task<IDataResult<UpdateEducationDto>> GetUpdateEducationAsync(int id)
    {
        Education education = await Repository.GetRepository<Education>().GetAsync(e => e.Id == id);

        if (education == null)
            return new DataResult<UpdateEducationDto>(ResultStatus.Error, "Sistemde böyle bir eğitim bilgisi bulunmamaktadır.");

        UpdateEducationDto updateEducationDto = Mapper.Map<UpdateEducationDto>(education);
        return new DataResult<UpdateEducationDto>(ResultStatus.Success, updateEducationDto);
    }


    [CacheRemoveAspect("IEducationService.Get")]
    public async Task<IResult> UpdateEducationAsync(UpdateEducationDto updateEducationDto)
    {
        if (updateEducationDto == null)
            return new Result(ResultStatus.Error, "Sistemde böyle bir eğitim bilgisi bulunmamaktadır.");

        Education education = await Repository.GetRepository<Education>().GetAsync(e => e.Id == updateEducationDto.Id);
        Mapper.Map<Education, UpdateEducationDto>(education);
        await Repository.GetRepository<Education>().UpdateAsync(education);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Updated);
    }
}
