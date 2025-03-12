using AutoMapper;
using Business.Abstract;
using Business.Concrete.Base;
using Business.Helpers.Validations;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;

namespace Business.Concrete
{
    public class UserManager : BaseManager, IUserService
    {
        public UserManager(IValidationHelper validationHelper, IRepository repository, IMapper mapper) : base(validationHelper, repository, mapper)
        {
        }

        public async Task<IDataResult<GetUserSidebarDto>> GetUserSidebarDtoAsync()
        {
            User user = await Repository.GetRepository<User>().GetAsync();
            var userSidebarDto = Mapper.Map<GetUserSidebarDto>(user);
            return new DataResult<GetUserSidebarDto>(ResultStatus.Success, userSidebarDto);
        }
    }
}
