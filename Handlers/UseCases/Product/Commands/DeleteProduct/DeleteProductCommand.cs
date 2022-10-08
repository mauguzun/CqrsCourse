using Handlers.CqrsFramework;
using Handlers.UseCases.Common.Commands.DeleteEntity;

namespace Handlers.UseCases.Product.Commands.DeleteProduct
{
    public class DeleteProductCommand : DeleteEntityCommand ,IRequest
    {
    }
}
