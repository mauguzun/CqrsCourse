using ApplicationServices.Interfaces;
using System.Collections.Generic;

namespace Layers.ApplicationServices.Interfaces
{
    public class ChangeOrderDto
    {
        public List<OrderItemDto> Items { get; set; }
    }
}
