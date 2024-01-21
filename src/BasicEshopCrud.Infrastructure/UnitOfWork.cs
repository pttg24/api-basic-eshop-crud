using System;
using System.Threading.Tasks;

namespace BasicEshopCrud.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private bool _disposed;

    public UnitOfWork(BasicEshopCrudContext context)
    {
        this._disposed = false;
        this.Context = context;
    }
    public BasicEshopCrudContext Context { get; }

    /// <summary>
    /// Commits the asynchronous.
    /// </summary>
    public async Task CommitAsync()
    {
        await this.Context.SaveChangesAsync();
    }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public virtual void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// Releases unmanaged and - optionally - managed resources.
    /// </summary>
    /// <param name="disposing">
    /// <c>true</c> to release both managed and unmanaged resources;
    /// <c>false</c> to release only unmanaged resources.
    /// </param>
    protected virtual void Dispose(bool disposing)
    {
        if (this._disposed)
            return;

        this._disposed = true;
    }
}
