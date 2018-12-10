using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
using CqrsDemo.Application.CQRS;
using Microsoft.Extensions.Logging;

namespace CqrsDemo.Infrastructure.CQRS
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly ILogger<CommandDispatcher> _logger;
        private readonly ICommandHandlersResolver _commandHandlersResolver;

        private readonly ConcurrentDictionary<Type, Type> _commandHandlerWrapperTypes =
            new ConcurrentDictionary<Type, Type>();

        private readonly ConcurrentDictionary<Type, object> _commandHandlerWrappers =
            new ConcurrentDictionary<Type, object>();

        public CommandDispatcher(ICommandHandlersResolver commandHandlersResolver, ILogger<CommandDispatcher> logger)
        {
            _commandHandlersResolver = commandHandlersResolver;
            _logger = logger;
        }

        public Task Execute(ICommand<VoidResult> command)
        {
            return Execute<VoidResult>(command);
        }

        public Task<TResponse> Execute<TResponse>(ICommand<TResponse> command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var handlerWrapper = GetCommandHandlerWrapperType(command);
            
            return handlerWrapper.Execute(command);
        }

        private CommandHandlerWrapperBase<TResponse> GetCommandHandlerWrapperType<TResponse>(
            ICommand<TResponse> command)
        {
            var commandType = command.GetType();

            var commandHandlerWrapperType = _commandHandlerWrapperTypes.GetOrAdd(commandType,
                (type) => typeof(CommandHandlerWrapper<,>).MakeGenericType(commandType, typeof(TResponse)));
            
            return (CommandHandlerWrapperBase<TResponse>) _commandHandlerWrappers.GetOrAdd(commandHandlerWrapperType,
                t =>
                    Activator.CreateInstance(commandHandlerWrapperType,
                        _commandHandlersResolver));

        }
    }
}