using ApplicationServices.Interfaces;
using AutoMapper;
using Handlers.UseCases.Common.Queries.GetEntityById;
using Infrastructure.Interfaces;

namespace Handlers.UseCases.Order.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler : GetEntityByIdQueryHandler<GetOrderByIdQuery, Entities.Order, OrderDto>
    {

        public GetOrderByIdQueryHandler(IReadOnlyDbContext dbContext, IMapper mapper) : base(dbContext, mapper)
        {
        }


    }
}
