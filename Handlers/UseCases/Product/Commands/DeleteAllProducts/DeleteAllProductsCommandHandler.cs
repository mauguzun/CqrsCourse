using Handlers.CqrsFramework;
using Handlers.UseCases.Product.Commands.DeleteProduct;
using Infrastructure.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace Handlers.UseCases.Product.Commands.DeleteAllProducts
{
    public class DeleteAllProductsCommandHandler : RequestHandler<DeleteAllProductsCommand>
    {
        private readonly IHandlerDispatcher _dispatcher;
        private readonly IDbContext _dbContext;

        public DeleteAllProductsCommandHandler(IHandlerDispatcher dispatcher, IDbContext dbContext)
        {
            _dispatcher = dispatcher;
            this._dbContext = dbContext;
        }

        protected override async Task HandleAsync(DeleteAllProductsCommand request)
        {
            using (var transaction = _dbContext.BeginTransaction())
            {

                //var tasks = request.Dto.Ids.Select(x =>
                //     _dispatcher.SendAsync(new DeleteProductCommand { Id = x })
                //);

                //await Task.WhenAll(tasks);
                request.Dto.Ids.ToList().ForEach(async id =>
                {
                    await _dispatcher.SendAsync(new DeleteProductCommand { Id = id });
                });

                transaction.Commit();
            }
        }
    }
}
