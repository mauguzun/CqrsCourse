using Handlers.CqrsFramework;

namespace Handlers.UseCases.Order.Commands.CreateOrder
{
    public abstract class CreateEntityCommand<TDto> : IRequest<int>
    {
        public TDto Dto { get; set; }
    }
}
