using System.Threading.Tasks;
using CqrsDemo.Host.CQRS;

namespace CqrsDemo.Application.CQRS
{
    internal class CommandDispatcher : ICommandDispatcher
    {
        private readonly ICommandHandlerResolver _resolver;
        
        public CommandDispatcher(ICommandHandlerResolver resolver)
        {
            _resolver = resolver;
        }

        public Task Execute<TCommand>(TCommand command) where TCommand : ICommand
        {
            var commandhandler = _resolver.Resolve<TCommand>();

            return commandhandler.Execute(command);
        }
    }
}
