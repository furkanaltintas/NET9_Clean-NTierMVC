using AutoMapper;
using Entities.Concrete;
using System.Reflection;

namespace Business.AutoMapper.Profiles;

public class AutoMappingProfile : Profile
{
    public AutoMappingProfile()
    {
        Assembly assembly = typeof(About).Assembly;

        string entityNamespace = "Entities.Concrete";
        string dtoNamespace = "Entities.Dtos";

        List<Type> entityTypes = assembly.GetTypes()
            .Where(t => t.Namespace != null && t.Namespace.StartsWith(entityNamespace))
            .ToList();

        List<Type> dtoTypes = assembly.GetTypes()
            .Where(t => t.Namespace != null && t.Namespace.StartsWith(dtoNamespace))
            .ToList();

        foreach (var entityType in entityTypes)
        {
            // Entity adını içeren tüm DTO'ları bul (örneğin: About -> GetAboutDto, CreateAboutDto, UpdateAboutDto)
            List<Type> matchingDtos = dtoTypes
                .Where(dto => dto.Name.Contains(entityType.Name)) // "About" geçen tüm DTO'ları bul
                .ToList();

            foreach (var dtoType in matchingDtos)
                CreateMap(dtoType, entityType)
                    .ReverseMap()
                    .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null)); // DTO <-> Entity otomatik eşleme
        }
    }
}