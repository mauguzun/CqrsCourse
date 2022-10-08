using System.Threading.Tasks;

namespace CQ.CqrsFramework
{
    public interface ICommandDispatcher
    {
        Task SendAsync<TCommand>(TCommand request)  where TCommand : ICommand;
    }
}
