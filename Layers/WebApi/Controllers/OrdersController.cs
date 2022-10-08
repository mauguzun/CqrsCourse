using ApplicationServices.Interfaces;
using Layers.ApplicationServices.Interfaces;
using Layers.WebApi;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IReadOnlyOrderService _readOnlyOrderService;

        public OrdersController(IOrderService orderService, IReadOnlyOrderService readOnlyOrderService)
        {
            _orderService = orderService;
            _readOnlyOrderService = readOnlyOrderService;
        }

        [CheckOrderFilter]
        [HttpGet("{id}")]
        public Task<OrderDto> GetByIdAsync(int id)
        {
            return _readOnlyOrderService.GetByIdAsync(id);
        }

        [HttpPost]
        public Task<int> CreateAsync([FromBody] ChangeOrderDto dto)
        {
            return _orderService.CreateAsync(dto);
        }

        [HttpPut("{id}")]
        public Task UpdateAsync(int id, [FromBody] ChangeOrderDto dto)
        {
            return _orderService.UpdateAsync(id, dto);
        }

    }
}
