using System.Threading.Tasks;

namespace CqrsDemo.Application.CQRS
{
    public interface ICommandDispatcher
    {
        Task Execute<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
