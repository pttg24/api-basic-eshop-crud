using System.Threading.Tasks;

namespace BasicEshopCrud.Infrastructure;

public interface IUnitOfWork
{
    BasicEshopCrudContext Context { get; }

    Task CommitAsync();
}
