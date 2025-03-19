using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;

namespace Business.Modules.Contacts.Services;

public interface IContactService
{
    Task<IResult> SendAsync(CreateContactDto createContactDto);

    Task<IDataResult<IList<GetAllContactDto>>> GetAllContactsAsync();

    Task<IDataResult<GetContactDto>> GetContactByIdAsync(int id);

    Task<IResult> DeleteContactByIdAsync(int id);
}