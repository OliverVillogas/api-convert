using ConvertAPI.Contexts.Converts.Domain.Commands;
using ConvertAPI.Contexts.Converts.Domain.Model.Entities;

namespace ConvertAPI.Contexts.Converts.Domain.Services;

public interface IConvertCommandService
{
    Task<ConvertEntity> Handle(CreateConvertCommand command);
}