using Handlers.CqrsFramework;

namespace Handlers.UseCases.Product.Commands.DeleteAllProducts
{
    public class DeleteAllProductsCommand :IRequest
    {
        public DeleteAllDto Dto { get; set; }
    }
}
