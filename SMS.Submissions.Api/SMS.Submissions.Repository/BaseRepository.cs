using Microsoft.EntityFrameworkCore;
using SMS.Submissions.CrossCutting.Extensions;
using SMS.Submissions.Domain.Abstractions.Repositories;
using SMS.Submissions.Domain.Abstractions.Settings;
using SMS.Submissions.Repository.Context;

namespace SMS.Submissions.Repository;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity
{
    private readonly ApplicationDbContext _context;
    protected readonly DbSet<TEntity> Entity;

    public BaseRepository(ApplicationDbContext context)
    {
        _context = context;
        Entity = context.Set<TEntity>();
    }

    public async Task<TEntity> Add(TEntity entity)
    {
        var newEntity = await Entity.AddAsync(entity);
        await _context.SaveChangesAsync();

        return newEntity.Entity;
    }

    public async Task<List<TEntity>> GetAll()
    {
        return await Entity.OrderBy(x => x.CreatedDate).ToListAsync();
    }

    public async Task<TEntity?> GetById(long id) => await Entity.FirstOrDefaultAsync(x => x.Id == id);

    public async Task Remove(TEntity entity)
    {
        Entity.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Update(TEntity entity)
    {
        DetachLocal(_ => _.Id == entity.Id);
        Entity.Update(entity);
        await _context.SaveChangesAsync();
    }

    private void DetachLocal(Func<TEntity, bool> predicate)
    {
        var local = _context.Set<TEntity>().Local.Where(predicate).FirstOrDefault();
        if (!local.IsNull())
        {
            _context.Entry(local).State = EntityState.Detached;
        }
    }
}