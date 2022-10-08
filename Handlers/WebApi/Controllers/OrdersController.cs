﻿using ApplicationServices.Interfaces;
using Handlers.CqrsFramework;
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
    public class OrdersController : ControllerBase
    {
        [HttpGet("{id}")]
        public Task<OrderDto> GetByIdAsync(int id, [FromServices] IRequestHandler<GetOrderByIdQuery, OrderDto> handler)
        {
            return handler.HandleAsync(new GetOrderByIdQuery { Id = id });
        }

        [HttpPost]
        public Task<int> CreateAsync([FromBody] ChangeOrderDto dto, [FromServices] IRequestHandler<CreateOrderCommand, int> handler)
        {
            return handler.HandleAsync(new CreateOrderCommand { Dto = dto });
        }

        [HttpPut("{id}")]
        public Task UpdateAsync(int id, [FromBody] ChangeOrderDto dto, [FromServices] IRequestHandler<UpdateOrderCommand> handler)
        {
            return handler.HandleAsync(new UpdateOrderCommand { Id = id, Dto = dto });
        }

    }
}
