using ConvertAPI.Contexts.Converts.Domain.Commands;
using ConvertAPI.Contexts.Converts.Domain.Model.Entities;
using ConvertAPI.Contexts.Converts.Interfaces.REST.Resources;

namespace ConvertAPI.Contexts.Converts.Interfaces.REST.Transform;

public static class ConvertResourceAssembler
{
    public static CreateConvertCommand ToCommandFromResource(CreateConvertResource resource)
    {
        return new CreateConvertCommand(resource.Kilograms);
    }

    public static ConvertResource ToResourceFromEntity(ConvertEntity entity)
    {
        return new ConvertResource(
            entity.Result.Kilograms,
            entity.Result.Pounds
        );
    }

    public static IEnumerable<ConvertResource> ToResourceFromEntity(IEnumerable<ConvertEntity> entities)
    {
        return entities.Select(ToResourceFromEntity);
    }
}