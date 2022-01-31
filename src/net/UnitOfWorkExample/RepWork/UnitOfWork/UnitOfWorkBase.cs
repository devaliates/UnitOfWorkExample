namespace RepWork.UnitOfWork;

public class UnitOfWorkBase<TDbContext>
    : IUnitOfWork
    where TDbContext : DbContext, new()
{
    protected TDbContext context;
    private bool disposed;
    private IDbContextTransaction? transaction;

    public UnitOfWorkBase(TDbContext context)
    {
        this.context = context;
        this.disposed = false;
    }

    public async Task<UnitOfWorkBase<TDbContext>> BeginTransactionAsync()
    {
        this.transaction = await context.Database.BeginTransactionAsync();
        return await Task.FromResult(this);
    }

    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    public async Task<int> Save()
    {
        try
        {
            var i = await this.context.SaveChangesAsync();

            if (this.transaction != null)
                await this.transaction.CommitAsync();

            return await Task.FromResult(i);
        }
        catch (Exception)
        {
            await this.transaction?.RollbackAsync();
            throw;
        }
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!this.disposed)
        {
            if (disposing)
            {
                this.context.Dispose();
            }
        }
        this.disposed = true;
    }
}