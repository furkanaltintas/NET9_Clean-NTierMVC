using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;

namespace Business.Modules.Users.Services;

public interface IUserService
{
    Task<IDataResult<GetUserSidebarDto>> GetSidebarDataAsync();
}