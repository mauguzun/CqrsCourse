using Castle.DynamicProxy;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Layers.ApplicationServices.Implementation.Order
{
    public class CheckOrderAsynInterceptor : AsyncInterceptorBase
    {
        private readonly ICurrentUserService _currentUserService;
        private readonly IDbContext _dbContext;

        public CheckOrderAsynInterceptor(ICurrentUserService currentUserService, IDbContext dbContext)
        {
            _currentUserService = currentUserService;
            _dbContext = dbContext;
        }

        protected override Task InterceptAsync(IInvocation invocation, IInvocationProceedInfo proceedInfo, Func<IInvocation, IInvocationProceedInfo, Task> proceed)
        {
            var attr = invocation.MethodInvocationTarget.GetCustomAttributes<CheckOrderAttribite>();
            if (attr != null)
            {
                CheckOrderAsyn((int)invocation.Arguments[0]);
            }

            return proceed(invocation, proceedInfo);
        }

        protected override async Task<TResult> InterceptAsync<TResult>(IInvocation invocation, IInvocationProceedInfo proceedInfo, Func<IInvocation, IInvocationProceedInfo, Task<TResult>> proceed)
        {
            var attr = invocation.MethodInvocationTarget.GetCustomAttributes<CheckOrderAttribite>();
            if (attr != null)
            {
                await CheckOrderAsyn((int)invocation.Arguments[0]);
            }

            return await proceed(invocation, proceedInfo);
        }

        private async Task CheckOrderAsyn(int id)
        {
            var count = await _dbContext.Orders.CountAsync(x => x.UserEmail == _currentUserService.Email && x.Id == id);
            if (count != 1) { throw new Exception("Order not found"); }
        }
    }
}
