using Microsoft.EntityFrameworkCore.Storage;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Interfaces
{
    public interface IDbContext : IReadOnlyDbContext
    {

        IDbContextTransaction BeginTransaction();
        Task<int> SaveChangesAsync(CancellationToken token = default);
    }
}
