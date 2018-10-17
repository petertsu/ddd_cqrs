using System;
using System.Threading.Tasks;
using CqrsDemo.Application.CQRS;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SimpleInjector;

namespace CqrsDemo.Host.CQRS
{
    public class SinmpleInjectorCommandDispatcher : ICommandDispatcher
    {
        private readonly ILogger<SinmpleInjectorCommandDispatcher> _logger;
        private readonly Container _ioc;

        public SinmpleInjectorCommandDispatcher(Container ioc, ILogger<SinmpleInjectorCommandDispatcher> logger)
        {
            _ioc = ioc;
            _logger = logger;
        }

        public Task<TResponse> Execute<TResponse>(ICommand<TResponse> command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var handlerType =
                typeof(RequestHandlerWrapperImpl<,>).MakeGenericType(command.GetType(), typeof(TResponse));

            var wrapper = (RequestHandlerWrapper<TResponse>) Activator.CreateInstance(handlerType, _ioc);

            return wrapper.Handle(command);

        }

        public Task Execute(ICommand<VoidResult> command)
        {
            return Execute<VoidResult>(command);
        }
    }
}