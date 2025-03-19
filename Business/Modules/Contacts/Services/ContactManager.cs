using AutoMapper;
using Business.Constants;
using Business.Modules.Contacts.Constants;
using Business.Modules.Contacts.Validations;
using Core.Aspects.Autofac.Validation;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;

namespace Business.Modules.Contacts.Services;

public class ContactManager : BaseManager, IContactService
{
    private const string Contact = "Contact";
    public ContactManager(IRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }

    public async Task<IResult> DeleteContactByIdAsync(int id)
    {
        Contact contact = await Repository.GetRepository<Contact>().GetAsync(
            c => c.Id == id);

        if (contact == null)
            return new Result(ResultStatus.Error, Messages.InvalidValue(Contact));

        await Repository.GetRepository<Contact>().HardDeleteAsync(contact);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Deleted(Contact));
    }

    public async Task<IDataResult<IList<GetAllContactDto>>> GetAllContactsAsync()
    {
        var contacts = await Repository.GetRepository<Contact>().GetAllAsync();

        var getAllContactDtos = Mapper.Map<List<GetAllContactDto>>(contacts);
        return new DataResult<IList<GetAllContactDto>>(ResultStatus.Success, getAllContactDtos);
    }

    public async Task<IDataResult<GetContactDto>> GetContactByIdAsync(int id)
    {
        Contact contact = await Repository.GetRepository<Contact>().GetAsync(
            c => c.Id == id);

        if (contact == null)
            return new DataResult<GetContactDto>(ResultStatus.Error, Messages.InvalidValue(Contact));

        return new DataResult<GetContactDto>(ResultStatus.Success);
    }


    [ValidationAspect(typeof(CreateContactValidator), Priority = 1)]
    public async Task<IResult> SendAsync(CreateContactDto createContactDto)
    {
        Contact contact = Mapper.Map<Contact>(createContactDto);
        await Repository.GetRepository<Contact>().AddAsync(contact);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, ContactsMessages.MessageSent);
    }
}