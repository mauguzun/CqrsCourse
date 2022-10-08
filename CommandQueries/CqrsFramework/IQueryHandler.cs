using System.Threading.Tasks;

namespace CQ.CqrsFramework
{
    public interface IQueryHandler<TRequest, TResponse>
    {
        Task<TResponse> HandleAsync(TRequest request);
    }
}
