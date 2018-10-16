using System.Threading.Tasks;

namespace CqrsDemo.Application.CQRS
{
    public interface ICommandHandler<in TCommand>  where TCommand : ICommand
    {
        Task Execute(TCommand command);
    }
}
