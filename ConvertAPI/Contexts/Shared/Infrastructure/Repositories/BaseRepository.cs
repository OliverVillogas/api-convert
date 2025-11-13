using ConvertAPI.Contexts.Shared.Domain.Model.Entities;
using ConvertAPI.Contexts.Shared.Domain.Repositories;

namespace ConvertAPI.Contexts.Shared.Infrastructure.Repositories;

public class BaseRepository<TEntity> : IBaseRepository<TEntity>
    where TEntity : BaseEntity
{
    protected readonly List<TEntity> _data = new();
    protected int _nextId = 1;

    public Task<TEntity> AddAsync(TEntity entity)
    {
        entity.Id = _nextId++;
        entity.CreatedDate = DateTime.UtcNow;
        _data.Add(entity);
        return Task.FromResult(entity);
    }

    public Task<TEntity?> FindByIdAsync(int id)
    {
        var entity = _data.FirstOrDefault(e => e.Id == id);
        return Task.FromResult(entity);
    }

    public Task<IEnumerable<TEntity>> ListAsync()
    {
        return Task.FromResult(_data.AsEnumerable());
    }

    public Task<bool> DeleteAsync(int id)
    {
        var entity = _data.FirstOrDefault(e => e.Id == id);
        if (entity == null) return Task.FromResult(false);

        _data.Remove(entity);
        return Task.FromResult(true);
    }
}