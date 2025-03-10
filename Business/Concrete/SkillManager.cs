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

public class SkillManager : BaseManager, ISkillService
{
    public SkillManager(IValidationHelper validationHelper, IRepository repository, IMapper mapper) : base(validationHelper, repository, mapper)
    {
    }


    [CacheRemoveAspect("ISkillService.Get")]
    public async Task<IResult> AddSkillAsync(CreateSkillDto createSkillDto)
    {
        Skill skill = Mapper.Map<Skill>(createSkillDto);
        await Repository.GetRepository<Skill>().AddAsync(skill);
        return new Result(ResultStatus.Success, Messages.Added);
    }


    [CacheRemoveAspect("ISkillService.Get")]
    public async Task<IResult> DeleteSkillAsync(int id)
    {
        Skill skill = await Repository.GetRepository<Skill>().GetAsync(e => e.Id == id);

        if (skill == null)
            return new Result(ResultStatus.Error, "Sistemde böyle bir yetenek bilgisi bulunmamaktadır.");

        await Repository.GetRepository<Skill>().HardDeleteAsync(skill);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, "Yetenek bilgisi sistemden başarıyla silinmiştir");
    }


    [CacheAspect]
    public async Task<IDataResult<IList<GetAllSkillDto>>> GetAllAsync()
    {
        IList<Skill> skills = await Repository.GetRepository<Skill>().GetAllAsync();

        IList<GetAllSkillDto> getAllSkillDtos = Mapper.Map<IList<GetAllSkillDto>>(skills);
        return new DataResult<IList<GetAllSkillDto>>(ResultStatus.Success, getAllSkillDtos);
    }


    [CacheAspect]
    public async Task<IDataResult<GetSkillDto>> GetSkillAsync(int id)
    {
        Skill skill = await Repository.GetRepository<Skill>().GetAsync(e => e.Id == id);

        if (skill == null)
            return new DataResult<GetSkillDto>(ResultStatus.Error, "Sistemde böyle bir yetenek bilgisi bulunmamaktadır.");


        GetSkillDto getSkillDto = Mapper.Map<GetSkillDto>(skill);
        return new DataResult<GetSkillDto>(ResultStatus.Success, getSkillDto);
    }


    [CacheAspect]
    public async Task<IDataResult<UpdateServiceDto>> GetUpdateSkillAsync(int id)
    {
        Skill skill = await Repository.GetRepository<Skill>().GetAsync(e => e.Id == id);

        if (skill == null)
            return new DataResult<UpdateServiceDto>(ResultStatus.Error, "Sistemde böyle bir yetenek bilgisi bulunmamaktadır.");


        UpdateServiceDto updateServiceDto = Mapper.Map<UpdateServiceDto>(skill);
        return new DataResult<UpdateServiceDto>(ResultStatus.Success, updateServiceDto);
    }


    [CacheRemoveAspect("ISkillService.Get")]
    public async Task<IResult> UpdateSkillAsync(UpdateSkillDto updateSkillDto)
    {
        if (updateSkillDto == null)
            return new Result(ResultStatus.Error, "Sistemde böyle bir yetenek bilgisi bulunmamaktadır.");

        Skill skill = await Repository.GetRepository<Skill>().GetAsync(e => e.Id == updateSkillDto.Id);
        Mapper.Map<Skill, UpdateSkillDto>(skill);
        await Repository.GetRepository<Skill>().UpdateAsync(skill);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Updated);
    }
}