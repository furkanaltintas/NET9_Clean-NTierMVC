using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;

namespace Business.Abstract;

public interface IContactService
{
    Task<IResult> SendAsync(CreateContactDto createContactDto);
    Task<IDataResult<GetContactDto>> GetAboutAsync();
    Task<IResult> DeleteContactAsync(int id);
}