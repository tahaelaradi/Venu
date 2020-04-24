using System;
using System.Threading;
using System.Threading.Tasks;

namespace Venu.Ticketing.Domain.SeedWork
{
    public interface IUnitOfWork : IDisposable
    {        
        Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
