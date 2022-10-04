using SMS.Activities.Domain.Abstractions.Settings;

namespace SMS.Activities.Domain.Abstractions.Repositories;

public interface IBaseRepository<TEntity> where TEntity : Entity
{
    Task Remove(TEntity entity);
    Task<TEntity> Add(TEntity entity);
    Task Update(TEntity entity);
    Task<List<TEntity>> GetAll();
    Task<TEntity?> GetById(long id);
}