using System.Linq.Expressions;

namespace UnitOfWorkExample.Core;

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
}