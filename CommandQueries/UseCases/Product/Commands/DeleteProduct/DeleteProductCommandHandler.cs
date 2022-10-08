using Handlers.UseCases.Order.Commands.UpdateOrder;
using Infrastructure.Interfaces;

namespace CQ.UseCases.Product.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : DeleteEntityCommandHandler<DeleteProductCommand, Entities.Product>
    {
        public DeleteProductCommandHandler(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
