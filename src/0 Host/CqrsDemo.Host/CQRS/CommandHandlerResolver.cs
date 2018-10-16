using System;
using CqrsDemo.Application.CQRS;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;

namespace CqrsDemo.Host.CQRS
{
    class CommandHandlerResolver : ICommandHandlerResolver
    {
        private readonly Container _ioc;
        public CommandHandlerResolver(Container ioc)
        {
            _ioc = ioc;
        }

        public ICommandHandler<TCommand> Resolve<TCommand>() where TCommand : ICommand
        {
            var handlerType =
                typeof(ICommandHandler<>).MakeGenericType(typeof(TCommand));

            var handler = _ioc.GetRequiredService(handlerType) as ICommandHandler<TCommand>;

            if(handler==null)
                throw new InvalidOperationException($"Could not resolve command handler {handlerType}");

            return handler;
        }
    }
}
