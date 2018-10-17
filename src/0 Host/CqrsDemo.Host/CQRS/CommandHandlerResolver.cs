using System;
using CqrsDemo.Application.CQRS;
using CqrsDemo.Infrastructure.CQRS;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;

namespace CqrsDemo.Host.CQRS
{
    class SimpleInjectorCommandHandlerResolver : ICommandHandlerResolver
    {
        private readonly Container _ioc;

        public SimpleInjectorCommandHandlerResolver(Container ioc)
        {
            _ioc = ioc;
        }
        
        public ICommandHandler<ICommand<TResponse>,TResponse> Resolve<TResponse>(ICommand<TResponse> command)
        {
            var handlerType = typeof(ICommandHandler<,>).MakeGenericType(command.GetType(), typeof(TResponse));

            var handler = _ioc.GetRequiredService(handlerType) as ICommandHandler<ICommand<TResponse>, TResponse>;

            if (handler == null)
                throw new InvalidOperationException($"{nameof(SimpleInjectorCommandHandlerResolver)} could not resolve command handler {handlerType}");
            
            return handler;
        }
    }
}
