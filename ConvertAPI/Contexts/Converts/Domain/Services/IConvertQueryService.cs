using ConvertAPI.Contexts.Converts.Domain.Model.Entities;
using ConvertAPI.Contexts.Converts.Domain.Queries;

namespace ConvertAPI.Contexts.Converts.Domain.Services;

public interface IConvertQueryService
{
    Task<IEnumerable<ConvertEntity>> Handle(GetAllConverts query);
    Task<ConvertEntity?> Handle(GetConvertById query);
}