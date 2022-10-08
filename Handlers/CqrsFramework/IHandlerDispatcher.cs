using System.Threading.Tasks;

namespace Handlers.CqrsFramework
{
    public interface IHandlerDispatcher
    {
        Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request);
    }

}
