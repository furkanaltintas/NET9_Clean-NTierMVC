using AutoMapper;
using Business.Constants;
using Business.Modules.Abouts.Rules;
using Business.Modules.Abouts.Validations;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Secured;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;

namespace Business.Modules.Abouts.Services;

public class AboutManager : BaseManager, IAboutService
{
    private const string About = "About";
    private readonly AboutBusinessRules _aboutBusinessRules;
    public AboutManager(IRepository repository, IMapper mapper, AboutBusinessRules aboutBusinessRules) : base(repository, mapper)
    {
        _aboutBusinessRules = aboutBusinessRules;
    }


    [ValidationAspect(typeof(CreateAboutValidator))]
    [CacheRemoveAspect("IAboutService.Get")]
    public async Task<IResult> CreateAboutAsync(CreateAboutDto createAboutDto)
    {
        About about = Mapper.Map<About>(createAboutDto);
        await Repository.GetRepository<About>().AddAsync(about);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Created(About));
    }


    [CacheRemoveAspect("IAboutService.Get")]
    public async Task<IResult> DeleteAboutAsync()
    {
        About about = await Repository.GetRepository<About>().GetAsync();

        if (about is null)
            return new Result(ResultStatus.Error, "Böyle bir hakkımda sayfası bulunamadı");

        await Repository.GetRepository<About>().HardDeleteAsync(about);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Deleted(About));

    }


    [CacheAspect(10)]
    public async Task<IDataResult<GetAboutDto>> GetAboutAsync()
    {
        DataResult<GetAboutDto> result = BusinessRules.Run<GetAboutDto>(await _aboutBusinessRules.CheckIfAboutExists());

        if (result != null)
            return new DataResult<GetAboutDto>(ResultStatus.Success, new("\"Henüz kendimi bile tam olarak tanımadığım için burada bir 'Hakkım da' kısmı yok.\""));

        About about = await Repository.GetRepository<About>().GetAsync();
        GetAboutDto aboutDto = Mapper.Map<GetAboutDto>(about);

        return new DataResult<GetAboutDto>(ResultStatus.Success, aboutDto);
    }


    public async Task<IDataResult<UpdateAboutDto>> GetAboutForUpdateAsync()
    {
        DataResult<UpdateAboutDto> result = BusinessRules.Run<UpdateAboutDto>(await _aboutBusinessRules.CheckIfAboutExists());

        if (result != null)
            return new DataResult<UpdateAboutDto>(ResultStatus.Success, new());

        About about = await Repository.GetRepository<About>().GetAsync();
        UpdateAboutDto updateAboutDto = Mapper.Map<UpdateAboutDto>(about);

        return new DataResult<UpdateAboutDto>(ResultStatus.Success, updateAboutDto);
    }


    [ValidationAspect(typeof(UpdateAboutValidator))]
    [CacheRemoveAspect("IAboutService.Get")]
    public async Task<IResult> UpdateAboutAsync(UpdateAboutDto updateAboutDto)
    {
        if (updateAboutDto.Id == 0)
            return await CreateAboutAsync(new CreateAboutDto { Description = updateAboutDto.Description });

        About about = Mapper.Map<About>(updateAboutDto);
        await Repository.GetRepository<About>().UpdateAsync(about);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Updated(About));
    }
}