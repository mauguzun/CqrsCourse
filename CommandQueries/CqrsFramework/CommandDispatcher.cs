using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace CQ.CqrsFramework
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task SendAsync<TCommand>(TCommand request) where TCommand : ICommand
        {
            var handler = _serviceProvider.GetRequiredService<ICommandHandler<TCommand>>();
            return handler.HandleAsync(request);
        }
    }
}
