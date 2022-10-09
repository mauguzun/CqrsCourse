using Handlers.CqrsFramework;

namespace Handlers.UseCases.Order.Commands.UpdateOrder
{
    public abstract class UpdateEntityCommand<TDto> : IRequest
    {
        public int Id { get; set; }
        public TDto Dto { get; set; }
    }
}
