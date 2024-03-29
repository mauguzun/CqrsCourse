﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Handlers.CqrsFramework
{
    public class HandlerDispatcher : IHandlerDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public HandlerDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task<TResponse> SendAsync<TResponse>(IRequest<TResponse> request)
        {
            var methodInfo = this.GetType().GetMethod(nameof(HandleAsync),
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).MakeGenericMethod(request.GetType(), typeof(TResponse));
            var result = methodInfo.Invoke(this, new object[] { request });
            return (Task<TResponse>)result;
        }


        protected Task<TResponse> HandleAsync<TRequest, TResponse>(TRequest request) where TRequest : IRequest<TResponse>
        {
            var handler = _serviceProvider.GetRequiredService<IRequestHandler<TRequest, TResponse>>();

            var midlleware = _serviceProvider.GetServices<IMiddleware<TRequest, TResponse>>();
            HanldeDelegate<TResponse> hanldeDelegate = () => handler.HandleAsync(request);

            var result = midlleware.Aggregate(hanldeDelegate, (next, midlleware) => () => midlleware.HandleAsync(request, next));

            return result();
        }
    }
}
