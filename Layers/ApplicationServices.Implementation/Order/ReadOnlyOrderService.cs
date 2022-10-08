using ApplicationServices.Interfaces;
using AutoMapper;
using Entities;
using Infrastructure.Interfaces;
using Layers.ApplicationServices.Implementation.Order;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Layers.ApplicationServices.Implementation
{
    public class ReadOnlyOrderService : ReadOnlyEntityService<Entities.Order, OrderDto>, IReadOnlyOrderService
    {
        public ReadOnlyOrderService(IReadOnlyDbContext dbContext, IMapper mapper)
            : base(dbContext, mapper) { }



        [CheckOrderAttribite]
        public override async Task<OrderDto> GetByIdAsync(int id)
        {
  
            return await base.GetByIdAsync(id);
        }

    }
}
