namespace MembershipSystem.Core.Interfaces;
/// <summary>
/// Common interface for data access repositories.
/// </summary>
public interface IRepository<TEntity, TKey> where TEntity : class {
    /// <summary>Gets an entity with the given id, or null if none is found.</summary>
    Task<TEntity?> GetByIdAsync(TKey id);

    /// <summary>Gets all entities.</summary>
    Task<IEnumerable<TEntity>> GetAllAsync();

    /// <summary>Adds an entity to the repository.</summary>
    Task AddAsync(TEntity entity);

    /// <summary>Updates an entity in the repository.</summary>
    Task UpdateAsync(TEntity entity);

    /// <summary>Delete an entity from the repository.</summary>
    Task DeleteAsync(TKey id);
    /// <summary>Delete an entity from the repository.</summary>
    Task DeleteAsync(TEntity entity);
}
