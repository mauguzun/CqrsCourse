﻿using ApplicationServices.Interfaces;
using Handlers.UseCases.Common.Queries.GetEntityById;

namespace Handlers.UseCases.Order.Queries.GetOrderById
{
    public class GetOrderByIdQuery : GetEntityByIdQuery<OrderDto>,  ICheckOrderReuest
    {
    }
}
