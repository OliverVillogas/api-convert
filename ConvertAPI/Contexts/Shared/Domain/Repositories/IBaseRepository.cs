namespace ConvertAPI.Contexts.Shared.Domain.Repositories;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<TEntity> AddAsync(TEntity entity);
    Task<TEntity?> FindByIdAsync(int id);
    Task<IEnumerable<TEntity>> ListAsync();
    Task<bool> DeleteAsync(int id);
}