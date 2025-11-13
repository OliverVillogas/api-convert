using ConvertAPI.Contexts.Converts.Domain.Model.Entities;
using ConvertAPI.Contexts.Shared.Domain.Repositories;

namespace ConvertAPI.Contexts.Converts.Domain.Repositories;

public interface IConvertRepository : IBaseRepository<ConvertEntity>
{
    // Domain-specific methods can be added here in the future
}