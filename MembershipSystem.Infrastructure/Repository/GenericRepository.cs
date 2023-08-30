using MembershipSystem.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MembershipSystem.Infrastructure.Repository;
public class GenericRepository<TEntity, TKey> : IRepository<TEntity, TKey> where TEntity : class {

    private readonly DbSet<TEntity> dbSet;

    public GenericRepository(DbSet<TEntity> dbSet) {
        this.dbSet = dbSet;
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync() {
        return await dbSet.ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(TKey id) {
        return await dbSet.FindAsync(id);
    }

    public async Task AddAsync(TEntity entity) {
        await dbSet.AddAsync(entity);
    }

    public Task UpdateAsync(TEntity entity) {
        dbSet.Update(entity);
        return Task.CompletedTask;
    }

    public async Task DeleteAsync(TKey id) {
        var entity = await dbSet.FindAsync(id);
        if (entity == null) {
            throw new InvalidOperationException($"{entity?.GetType()} with Id {id} could not be foudn");
        }
        dbSet.Remove(entity);
    }

    public Task DeleteAsync(TEntity entity) {
        dbSet.Remove(entity);
        return Task.CompletedTask;
    }
}
