using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;

namespace Business.Modules.Abouts.Services;

public interface IAboutService
{
    Task<IDataResult<GetAboutDto>> GetAboutAsync();
    Task<IDataResult<UpdateAboutDto>> GetAboutForUpdateAsync();
    Task<IResult> DeleteAboutAsync();
    Task<IResult> CreateAboutAsync(CreateAboutDto createAboutDto);
    Task<IResult> UpdateAboutAsync(UpdateAboutDto updateAboutDto);
}