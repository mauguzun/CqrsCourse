using CQ.CqrsFramework;
using CQ.UseCases.Product.Commands.DeleteProduct;
using Infrastructure.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace CQ.UseCases.Product.Commands.DeleteAllProducts
{
    public class DeleteAllProductsCommandHandler : ICommandHandler<DeleteAllProduct>
    {
        private readonly ICommandDispatcher commandDispatcher;
        private readonly IDbContext dbContext;

        public DeleteAllProductsCommandHandler(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task HandleAsync(DeleteAllProduct request)
        {
            using (var trans  =  dbContext.BeginTransaction ())
            {
                request.Dto.Ids.ToList().ForEach(async id =>
                {
                    await commandDispatcher.SendAsync(new DeleteProductCommand { Id = id });
                });

                await trans.CommitAsync();
            }
         
        }
    }
}
