namespace RepWork.Abstract.Repository;

/// <summary>
/// Generic Repository
/// </summary>
/// <typeparam name="TEntity"></typeparam>
/// <typeparam name="TDbContext">
/// Farklı DbContextleri DI yapmayı sağlar.
/// Eğer iki farklı DbContext varsa TDbContext ile ayrıla bilir.
/// </typeparam>
public interface IRepositoryBase<TEntity>
    where TEntity : class, new()
{
    public Task<IEnumerable<TEntity>> Get(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string includeProperties = "");

    public Task<TEntity> Get(Expression<Func<TEntity, bool>> filter);

    public Task Insert(TEntity entity);

    public Task Update(TEntity entity);

    public Task Delete(TEntity entity, string? propName);

    public Task Save();
}