using AutoMapper;
using Business.Constants;
using Business.Modules.Contacts.Constants;
using Core.Aspects.Autofac.Caching;
using Core.Helpers.Validators.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos;
using FluentValidation;
using Portfolio.Core.Utilities.Results.Abstract;
using Portfolio.Core.Utilities.Results.ComplexTypes;
using Portfolio.Core.Utilities.Results.Concrete;

namespace Business.Modules.Contacts.Services;

public class ContactManager : BaseManager, IContactService
{
    private readonly IValidator<CreateContactDto> _createContactValidator;
    public ContactManager(IRepository repository, IMapper mapper, IValidator<CreateContactDto> createContactValidator) : base(repository, mapper)
    {
        _createContactValidator = createContactValidator;
    }


    [CacheRemoveAspect("IContactService.Get")]
    public async Task<IResult> DeleteContactByIdAsync(int id)
    {
        Contact contact = await Repository.GetRepository<Contact>().GetAsync(c => c.Id == id);
        if (contact is null) return new Result(ResultStatus.Error, Messages.InvalidValue(ContactsMessages.Contact));

        await Repository.GetRepository<Contact>().HardDeleteAsync(contact);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, Messages.Deleted(ContactsMessages.Contact));
    }


    [CacheAspect]
    public async Task<IDataResult<IList<GetAllContactDto>>> GetAllContactsAsync()
    {
        IList<Contact> contacts = await Repository.GetRepository<Contact>().GetAllAsync();
        List<GetAllContactDto> getAllContactDtos = Mapper.Map<List<GetAllContactDto>>(contacts);
        return new DataResult<IList<GetAllContactDto>>(ResultStatus.Success, getAllContactDtos);
    }


    [CacheAspect]
    public async Task<IDataResult<GetContactDto>> GetContactByIdAsync(int id)
    {
        Contact contact = await Repository.GetRepository<Contact>().GetAsync(c => c.Id == id);
        if (contact is null) return new DataResult<GetContactDto>(ResultStatus.Error, Messages.InvalidValue(ContactsMessages.Contact));

        return new DataResult<GetContactDto>(ResultStatus.Success);
    }


    [CacheRemoveAspect("IContactService.Get")]
    //[ValidationAspect(typeof(CreateContactValidator))]
    public async Task<IResult> SendAsync(CreateContactDto createContactDto)
    {
        IResult result = await ValidatorResultHelper.ValidatorResult(_createContactValidator, createContactDto);
        if (result.ResultStatus == ResultStatus.Validation) return result;

        Contact contact = Mapper.Map<Contact>(createContactDto);
        await Repository.GetRepository<Contact>().AddAsync(contact);
        await Repository.SaveAsync();
        return new Result(ResultStatus.Success, ContactsMessages.MessageSent);
    }
}