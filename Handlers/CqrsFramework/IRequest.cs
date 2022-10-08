namespace Handlers.CqrsFramework
{
    public interface IRequest<TResponse>
    {

    }

    public interface IRequest : IRequest<Unit>
    {

    }

}
