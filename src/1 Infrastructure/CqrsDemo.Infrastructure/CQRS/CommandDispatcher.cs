using System;
using System.Threading.Tasks;
using CqrsDemo.Application.CQRS;
using Microsoft.Extensions.Logging;

namespace CqrsDemo.Infrastructure.CQRS
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly ILogger<CommandDispatcher> _logger;
        private readonly ICommandHandlerResolver _resolver;

        public CommandDispatcher(ICommandHandlerResolver resolver, ILogger<CommandDispatcher> logger)
        {
            _logger = logger;
            _resolver = resolver;
        }
      
        public Task<TResponse> Execute<TResponse>(ICommand<TResponse> command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command));

            var commandhandler = _resolver.Resolve(command);

            return commandhandler.Execute(command);
        }

        public Task Execute(ICommand<VoidResult> command)
        {
            return Execute<VoidResult>(command);
        }
    }
}