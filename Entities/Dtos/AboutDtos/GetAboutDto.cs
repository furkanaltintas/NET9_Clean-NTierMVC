using Core.Entities.Abstract;

namespace Entities.Dtos;

public class GetAboutDto : IDto
{
    public string Description { get; set; }


    public GetAboutDto()
    {

    }

    public GetAboutDto(string description)
    {
        Description = description;
    }
}