using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;

namespace Business.Abstract;

public interface IAboutService
{
    Task<IDataResult<GetAboutDto>> GetAboutAsync();
    Task<IDataResult<UpdateAboutDto>> GetUpdateAboutAsync();


    Task<IResult> DeleteAboutAsync();
    Task<IResult> AddAboutAsync(CreateAboutDto createAboutDto);
    Task<IResult> UpdateAboutAsync(UpdateAboutDto updateAboutDto);
}