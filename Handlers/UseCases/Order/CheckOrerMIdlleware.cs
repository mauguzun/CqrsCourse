using Handlers.CqrsFramework;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Handlers.UseCases.Order
{

    public class CheckOrerMIdlleware<TReqeust, TRespose> : IMiddleware<TReqeust, TRespose> where TReqeust : IRequest<TRespose>, ICheckOrderReuest
    {
        private readonly IDbContext dbContext;
        private readonly ICurrentUserService currentUserService;

        public CheckOrerMIdlleware(IDbContext dbContext, ICurrentUserService currentUserService)
        {
            this.dbContext = dbContext;
            this.currentUserService = currentUserService;
        }

        public async Task<TRespose> HandleAsync(TReqeust request, HanldeDelegate<TRespose> next)
        {
            var count = await dbContext.Orders.CountAsync(x => x.UserEmail == currentUserService.Email && x.Id == request.Id);
            if (count != 1) { throw new Exception("Order not found"); }

            return await next();
        }
    }
}
