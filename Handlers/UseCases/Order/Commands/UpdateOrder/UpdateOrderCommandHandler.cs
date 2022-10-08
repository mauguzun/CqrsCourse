﻿using AutoMapper;
using Infrastructure.Interfaces;
using Layers.ApplicationServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Handlers.UseCases.Order.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : UpdateEntityCommandHandler<UpdateOrderCommand, Entities.Order, ChangeOrderDto>
    {

        public UpdateOrderCommandHandler(IDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }

        protected override async Task<Entities.Order> GetTrackedEntityAsync(int id)
        {
            var order = await DbContext.Orders
                .Include(x => x.Items)
                .SingleAsync(x => x.Id == id);
            return order;
        }
    }
}
