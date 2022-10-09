using ApplicationServices.Interfaces;
using Handlers.CqrsFramework;
using Handlers.UseCases.Order.Commands.CreateOrder;
using Handlers.UseCases.Order.Commands.UpdateOrder;
using Handlers.UseCases.Order.Queries.GetOrderById;
using Handlers.UseCases.Product.Commands.DeleteAllProducts;
using Handlers.UseCases.Product.Commands.DeleteProduct;
using Layers.ApplicationServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {

        IHandlerDispatcher handlerDispatcher;

        public ProductsController(IHandlerDispatcher handlerDispatcher)
        {
            this.handlerDispatcher = handlerDispatcher;
        }


        [HttpGet("{id}")]
        public Task<ProductDto> GetByIdAsync(int id, [FromServices] IRequestHandler<GetProductByIdQuery, ProductDto> handler)
        {
            return handlerDispatcher.SendAsync(new GetProductByIdQuery { Id = id });
        }

        [HttpPost]
        public Task<int> CreateAsync([FromBody] ChangeProductDto dto, [FromServices] IRequestHandler<CreateProductCommand, int> handler)
        {
            return handlerDispatcher.SendAsync(new CreateProductCommand { Dto = dto });
        }

        [HttpPut("{id}")]
        public Task UpdateAsync(int id, [FromBody] ChangeProductDto dto, [FromServices] IRequestHandler<UpdateProductCommand> handler)
        {
            return handlerDispatcher.SendAsync(new UpdateProductCommand { Id = id, Dto = dto });
        }

        [HttpDelete("{id}")]
        public Task DeleteAsync(int id, [FromServices] IRequestHandler<DeleteProductCommand> handler)
        {
            return handlerDispatcher.SendAsync(new DeleteProductCommand { Id = id });
        }

        [HttpDelete]
        public Task DeleteAllAsync([FromBody]DeleteAllDto dto, [FromServices] IRequestHandler<DeleteAllProductsCommand> handler)
        {
            return handlerDispatcher.SendAsync(new DeleteAllProductsCommand { Dto = dto });
        }

    }
}
