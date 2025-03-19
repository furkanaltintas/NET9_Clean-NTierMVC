using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;

namespace Business.Modules.Auths.Services;

public interface IAuthService
{
    Task<IDataResult<GetUserDto>> SignInAsync(GetUserLoginDto getUserLoginDto);
    Task SignOutAsync();
}