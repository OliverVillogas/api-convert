using ConvertAPI.Contexts.Converts.Domain.Model.Entities;
using ConvertAPI.Contexts.Converts.Domain.Repositories;
using ConvertAPI.Contexts.Shared.Infrastructure.Repositories;

namespace ConvertAPI.Contexts.Converts.Infrastructure.Repositories;

public class ConvertRepository : BaseRepository<ConvertEntity>, IConvertRepository
{
    // Currently inherits everything from BaseRepository
}