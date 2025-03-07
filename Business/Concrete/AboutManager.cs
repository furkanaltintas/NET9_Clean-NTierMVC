using AutoMapper;
using Business.Abstract;
using Business.Concrete.Base;
using Business.Constants;
using Business.Helpers.Validations;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Repositories;
using Entities.Dtos.AboutDtos;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;
using PortfolioApp.Entities.Concrete;

namespace Business.Concrete
{
    public class AboutManager : BaseManager, IAboutService
    {
        public AboutManager(IValidationHelper validationHelper, IRepository repository, IMapper mapper) : base(validationHelper, repository, mapper)
        {
        }


        [ValidationAspect(typeof(AboutValidator), Priority = 1)]
        [CacheRemoveAspect("IAboutService.Get")]
        public async Task<IResult> AddAboutAsync(CreateAboutDto createAboutDto)
        {
            var result = BusinessRules.Run(
                await ValidationHelper.AboutValidationHelper.CheckIfAboutExists());

            if (result != null)
                return result;


            var about = Mapper.Map<About>(createAboutDto);
            await Repository.GetRepository<About>().AddAsync(about);
            await Repository.SaveChangesAsync();
        }

        public async Task<IResult> DeleteAboutAsync(int id)
        {
            var result = await Repository.GetRepository<About>().AnyAsync(a => a.Id == id);

            if (!result)
                return new Result(ResultStatus.Error, "Böyle bir hakkımda sayfası bulunamadı", null);

            var about = await Repository.GetRepository<About>().GetAsync(a => a.Id == id);
            await Repository.GetRepository<About>().HardDeleteAsync(about);
            await Repository.SaveChangesAsync();
            return new Result(ResultStatus.Success, Messages.Deleted);

        }


        [CacheAspect(10)]
        [PerformanceAspect(5)]
        public async Task<IDataResult<GetAboutDto>> GetAboutAsync()
        {
            var result = BusinessRules.Run<GetAboutDto>(
               await ValidationHelper.AboutValidationHelper.CheckIfAboutExists());

            if (result != null)
                return result;

            var about = await Repository.GetRepository<About>().GetAsync();
            var aboutDto = Mapper.Map<GetAboutDto>(about);

            return new DataResult<GetAboutDto>(ResultStatus.Success, aboutDto);
        }

        public string Test()
        {
            var test = Repository.GetRepository<About, AboutRepository>().Test();
            return test;
        }

        public async Task<IResult> UpdateAboutAsync(UpdateAboutDto updateAboutDto)
        {
            var about = Mapper.Map<About>(updateAboutDto);
            await Repository.GetRepository<About>().UpdateAsync(about);
            await Repository.SaveChangesAsync();
            return new Result(ResultStatus.Success, Messages.Updated);
        }
    }
}