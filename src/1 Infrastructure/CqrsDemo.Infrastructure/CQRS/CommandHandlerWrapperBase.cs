using System.Threading.Tasks;
using CqrsDemo.Application.CQRS;

namespace CqrsDemo.Infrastructure.CQRS
{
    internal abstract class CommandHandlerWrapperBase<TResponse>
    {
        protected ICommandHandlersResolver CommandHandlersResolver;
        protected CommandHandlerWrapperBase(ICommandHandlersResolver commandHandlersResolver)
        {
            CommandHandlersResolver = commandHandlersResolver;
        }

        public abstract Task<TResponse> Execute(ICommand<TResponse> request);
    }
}
