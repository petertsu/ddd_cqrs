using CqrsDemo.Application.CQRS;

namespace CqrsDemo.Host.CQRS
{
    public interface ICommandHandlerResolver
    {
        ICommandHandler<TCommand> Resolve<TCommand>() where TCommand : ICommand;
    }
}
