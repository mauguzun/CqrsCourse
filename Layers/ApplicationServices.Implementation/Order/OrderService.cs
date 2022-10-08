﻿using ApplicationServices.Interfaces;
using AutoMapper;
using Entities;
using Infrastructure.Interfaces;
using Layers.ApplicationServices.Implementation.Order;
using Layers.ApplicationServices.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ApplicationServices.Implementation
{
    public class OrderService : EntityService<Order, ChangeOrderDto>, IOrderService
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IStatisticService _statisticService;

        public OrderService(IDbContext dbContext,
            IMapper mapper,
            ICurrentUserService currentUserService,
            IStatisticService statisticService) : base(dbContext, mapper)
        {
            _currentUserService = currentUserService;
            _statisticService = statisticService;
        }

        protected override void InitializeNewEntity(Order entity)
        {
            entity.UserEmail = _currentUserService.Email;
        }

        public override async Task<int> CreateAsync(ChangeOrderDto dto)
        {
            await _statisticService.WriteStatisticAsync("Order", dto.Items.Select(x => x.ProductId));

            return await base.CreateAsync(dto);
        }

        protected override async Task<Order> GetTrackedEntityAsync(int id)
        {
            var order = await DbContext.Orders
                .Include(x => x.Items)
                .SingleAsync(x => x.Id == id);
            return order;
        }



        [CheckOrderAttribite]
        public override Task UpdateAsync(int id, ChangeOrderDto dto)
        {
          
            return base.UpdateAsync(id, dto);
        }

        public override Task DeleteAsync(int id)
        {
            throw new NotSupportedException();
        }
    }
}
