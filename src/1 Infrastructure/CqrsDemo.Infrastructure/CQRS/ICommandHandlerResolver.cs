using CqrsDemo.Application.CQRS;

namespace CqrsDemo.Infrastructure.CQRS
{
    public interface ICommandHandlerResolver
    {
        ICommandHandler<ICommand<TResponse>, TResponse> Resolve<TResponse>(ICommand<TResponse> command);
    }
}
