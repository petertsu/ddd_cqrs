using System.Threading.Tasks;

namespace CqrsDemo.Application.CQRS
{
    public interface ICommandHandler<in TCommand, TResponse>
        where TCommand : ICommand<TResponse>
    {
        Task<TResponse> Execute(TCommand command);
    }

    public interface ICommandHandler<in TCommand> : ICommandHandler<TCommand, VoidResult>
        where TCommand : ICommand<VoidResult>
    {
    }
}
