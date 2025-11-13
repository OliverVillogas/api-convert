using ConvertAPI.Contexts.Converts.Domain.Commands;
using ConvertAPI.Contexts.Converts.Domain.Exceptions;
using ConvertAPI.Contexts.Converts.Domain.Model.Entities;
using ConvertAPI.Contexts.Converts.Domain.Repositories;
using ConvertAPI.Contexts.Converts.Domain.Services;

namespace ConvertAPI.Contexts.Converts.Application.CommandServices;

public class ConvertCommandService(IConvertRepository repository) 
    : IConvertCommandService
{
    public async Task<ConvertEntity> Handle(CreateConvertCommand command)
    {
        
        if (command.Kilograms <= 0)
            throw new InvalidKilogramsException(command.Kilograms);

        var convert = new ConvertEntity(command.Kilograms);
        return await repository.AddAsync(convert);
    }
}