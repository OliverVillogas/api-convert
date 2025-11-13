using ConvertAPI.Contexts.Converts.Domain.Model.Entities;
using ConvertAPI.Contexts.Converts.Domain.Queries;
using ConvertAPI.Contexts.Converts.Domain.Repositories;
using ConvertAPI.Contexts.Converts.Domain.Services;

namespace ConvertAPI.Contexts.Converts.Application.QueryServices;

public class ConvertQueryService(IConvertRepository repository) 
    : IConvertQueryService
{
    public async Task<IEnumerable<ConvertEntity>> Handle(GetAllConverts query)
    {
        return await repository.ListAsync();
    }

    public async Task<ConvertEntity?> Handle(GetConvertById query)
    {
        return await repository.FindByIdAsync(query.Id);
    }
}