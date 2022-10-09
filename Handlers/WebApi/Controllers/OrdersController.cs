using ApplicationServices.Interfaces;
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
        IHandlerDispatcher handlerDispatcher;

        public OrdersController(IHandlerDispatcher handlerDispatcher)
        {
            this.handlerDispatcher = handlerDispatcher;
        }

        [HttpGet("{id}")]
        public Task<OrderDto> GetByIdAsync(int id)
        {
            return handlerDispatcher.SendAsync(new GetOrderByIdQuery { Id = id });
        }

        [HttpPost]
        public Task<int> CreateAsync([FromBody] ChangeOrderDto dto, [FromServices] IRequestHandler<CreateOrderCommand, int> handler)
        {
            return handlerDispatcher.SendAsync(new CreateOrderCommand { Dto = dto });
        }

        [HttpPut("{id}")]
        public Task UpdateAsync(int id, [FromBody] ChangeOrderDto dto, [FromServices] IRequestHandler<UpdateOrderCommand> handler)
        {
            return handlerDispatcher.SendAsync(new UpdateOrderCommand { Id = id, Dto = dto });
        }

    }
}
