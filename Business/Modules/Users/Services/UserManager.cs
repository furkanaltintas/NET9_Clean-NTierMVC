using AutoMapper;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;

namespace Business.Modules.Users.Services;

public class UserManager : BaseManager, IUserService
{
    public UserManager(IRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }

    public async Task<IDataResult<GetUserSidebarDto>> GetSidebarDataAsync()
    {
        User user = await Repository.GetRepository<User>().GetAsync();
        var userSidebarDto = Mapper.Map<GetUserSidebarDto>(user);
        return new DataResult<GetUserSidebarDto>(ResultStatus.Success, userSidebarDto);
    }
}