using Handlers.UseCases.Common.Commands.DeleteEntity;
using Infrastructure.Interfaces;

namespace Handlers.UseCases.Product.Commands.DeleteProduct
{
    public class DeleteProductCommandHandler : DeleteEntityCommandHandler<DeleteProductCommand, Entities.Product>
    {
        public DeleteProductCommandHandler(IDbContext dbContext) : base(dbContext)
        {
        }
    }
}
