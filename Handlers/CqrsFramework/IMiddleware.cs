using System.Threading.Tasks;

namespace Handlers.CqrsFramework
{

    public delegate Task<TResult> HanldeDelegate<TResult>();
    public interface IMiddleware<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {
        Task<TResponse> HandleAsync(TRequest request, HanldeDelegate<TResponse> next);
    }
}
