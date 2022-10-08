﻿using ApplicationServices.Interfaces;
using CQ.CqrsFramework;
using CQ.UseCases.Order.Dto;
using CQ.UseCases.Product.Commands.DeleteAllProducts;
using CQ.UseCases.Product.Commands.DeleteProduct;
using Handlers.UseCases.Order.Commands.CreateOrder;
using Handlers.UseCases.Order.Commands.UpdateOrder;
using Handlers.UseCases.Order.Queries.GetOrderById;
using Layers.ApplicationServices.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet("{id}")]
        public Task<ProductDto> GetByIdAsync(int id, [FromServices] IQueryHandler<GetProductByIdQuery, ProductDto> handler)
        {
            return handler.HandleAsync(new GetProductByIdQuery { Id = id });
        }

        [HttpPost]
        public async Task<int> CreateAsync([FromBody] ChangeProductDto dto, [FromServices] ICommandHandler<CreateProductCommand> handler)
        {
            var command = new CreateProductCommand { Dto = dto };
            await handler.HandleAsync(command);
            return command.Id;
        }

        [HttpPut("{id}")]
        public Task UpdateAsync(int id, [FromBody] ChangeProductDto dto, [FromServices] ICommandHandler<UpdateProductCommand> handler)
        {
            return handler.HandleAsync(new UpdateProductCommand { Id = id, Dto = dto });
        }


        [HttpDelete("{id}")]
        public Task DeleteAsync(int id, [FromServices] ICommandHandler<DeleteProductCommand> handler)
        {
            return handler.HandleAsync(new DeleteProductCommand { Id = id });
        }

        [HttpDelete]
        public Task DeleteAllAsync([FromBody] DeleteAllDto dto, [FromServices] ICommandHandler<DeleteAllProductsCommand> handler)
        {
            return handler.HandleAsync(new DeleteAllProductsCommand { Dto = dto });
        }
    }
}
