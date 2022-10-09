using Handlers.CqrsFramework;

namespace Handlers.UseCases.Common.Queries.GetEntityById
{
    public abstract class GetEntityByIdQuery<TDto> : IRequest<TDto>
    {
        public int Id { get; set; }
    }
}
