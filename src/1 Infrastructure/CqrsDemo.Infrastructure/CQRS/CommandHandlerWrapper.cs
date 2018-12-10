using System.Threading.Tasks;
using CqrsDemo.Application.CQRS;

namespace CqrsDemo.Infrastructure.CQRS
{
    internal class CommandHandlerWrapper<TRequest, TResponse> : CommandHandlerWrapperBase<TResponse>
        where TRequest : ICommand<TResponse>
    {
        private readonly ICommandHandlersResolver _commandHandlersResolver;
        public CommandHandlerWrapper(ICommandHandlersResolver commandHandlersResolver) : base(commandHandlersResolver)
        {
            _commandHandlersResolver = commandHandlersResolver;
        }

        public override Task<TResponse> Execute(ICommand<TResponse> request)
        {
            var commandHandler = _commandHandlersResolver.GetHandler<ICommandHandler<TRequest, TResponse>>();//  GetHandler<>();

            return commandHandler.Execute((TRequest)request);
        }
    }
}