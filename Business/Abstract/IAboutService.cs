using Entities.Dtos.AboutDtos;
using Portfolio.Core.Utilities.Results.Abstract;

namespace Business.Abstract;

public interface IAboutService
{
    Task<IDataResult<GetAboutDto>> GetAboutAsync();


    Task<IResult> DeleteAboutAsync(int id);
    Task<IResult> AddAboutAsync(CreateAboutDto createAboutDto);
    Task<IResult> UpdateAboutAsync(UpdateAboutDto updateAboutDto);

    string Test();
}