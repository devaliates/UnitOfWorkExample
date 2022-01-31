namespace UnitOfWorkExample.Core.Concrete;

public class EfRepositoryBase<TEntity>
    : IRepositoryBase<TEntity>
    where TEntity : class, new()
{
    private readonly DbContext context;
    private readonly DbSet<TEntity> dbSet;

    public EfRepositoryBase(DbContext context)
    {
        this.context = context;
        this.dbSet = context.Set<TEntity>();
    }

    public virtual async Task<IEnumerable<TEntity>> Get(
        Expression<Func<TEntity, bool>>? filter = null,
        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null,
        string includeProperties = "")
    {
        IQueryable<TEntity> query = dbSet;

        if (filter != null)
        {
            query = query.Where(filter);
        }

        foreach (var includeProperty in includeProperties.Split
            (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        {
            query = query.Include(includeProperty);
        }

        if (orderBy != null)
        {
            return await orderBy(query).ToListAsync();
        }
        else
        {
            return await query.ToListAsync();
        }
    }

    public virtual async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
    {
        return await dbSet.SingleAsync(filter);
    }

    public virtual async Task Insert(TEntity entity)
    {
        await dbSet.AddAsync(entity);
        await Task.CompletedTask;
    }

    public virtual async Task Update(TEntity entity)
    {
        dbSet.Attach(entity);
        context.Entry(entity).State = EntityState.Modified;
        await Task.CompletedTask;
    }

    public virtual async Task Delete(TEntity entity, string? propName)
    {
        if (propName != null)
        {
            TEntity _entity = entity;

            _entity.GetType().GetProperty(propName)?.SetValue(_entity, true);

            await this.Update(_entity);
        }
        else
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }
            dbSet.Remove(entity);
        }
        await Task.CompletedTask;
    }
}