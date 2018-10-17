using CqrsDemo.Application.CQRS;

namespace CqrsDemo.Infrastructure.CQRS
{
    public interface ICommandHandlerResolver
    {
        dynamic Resolve<TResponse>(ICommand<TResponse> command);
    }
}
