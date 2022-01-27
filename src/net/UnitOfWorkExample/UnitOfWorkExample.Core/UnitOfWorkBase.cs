using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace UnitOfWorkExample.Core;

public class UnitOfWorkBase
    : IDisposable
{
    protected DbContext context;
    private Dictionary<string, object> repos;
    private bool disposed;
    private IDbContextTransaction? transaction;

    public UnitOfWorkBase(DbContext context)
    {
        this.context = context;
        this.repos = new Dictionary<string, object>();
        this.disposed = false;
    }

    public async Task<UnitOfWorkBase> BeginTransactionAsync()
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