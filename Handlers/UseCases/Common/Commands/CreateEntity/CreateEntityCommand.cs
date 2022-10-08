namespace Handlers.UseCases.Order.Commands.CreateOrder
{
    public abstract class CreateEntityCommand<TDto>
    {
        public TDto Dto { get; set; }
    }
}
