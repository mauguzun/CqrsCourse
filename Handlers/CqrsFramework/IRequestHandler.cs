using System.Threading.Tasks;

namespace Handlers.CqrsFramework
{
    public interface IRequestHandler<TRequest, TResponse>
    {
        Task<TResponse> HandleAsync(TRequest request);
    }

    public interface IRequestHandler<TRequest> : IRequestHandler<TRequest, Unit>
    {
    }
}
