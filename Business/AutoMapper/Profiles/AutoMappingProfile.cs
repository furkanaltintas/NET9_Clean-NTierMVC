using AutoMapper;
using Entities.Concrete;

namespace Business.AutoMapper.Profiles;

public class AutoMappingProfile : Profile
{
    public AutoMappingProfile()
    {
        var assembly = typeof(About).Assembly;

        var entityNamespace = "Entities.Concrete";
        var dtoNamespace = "Entities.Dtos";

        var entityTypes = assembly.GetTypes()
            .Where(t => t.Namespace != null && t.Namespace.StartsWith(entityNamespace))
            .ToList();

        var dtoTypes = assembly.GetTypes()
            .Where(t => t.Namespace != null && t.Namespace.StartsWith(dtoNamespace))
            .ToList();

        foreach (var entityType in entityTypes)
        {
            // Entity adını içeren tüm DTO'ları bul (örneğin: About -> GetAboutDto, CreateAboutDto, UpdateAboutDto)
            var matchingDtos = dtoTypes
                .Where(dto => dto.Name.Contains(entityType.Name)) // "About" geçen tüm DTO'ları bul
                .ToList();

            foreach (var dtoType in matchingDtos)
                CreateMap(dtoType, entityType).ReverseMap(); // DTO <-> Entity otomatik eşleme
        }
    }
}