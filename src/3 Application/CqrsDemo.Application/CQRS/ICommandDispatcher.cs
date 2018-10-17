using System.Threading.Tasks;


namespace CqrsDemo.Application.CQRS
{
    public interface ICommandDispatcher
    {
        Task<TResponse> Execute<TResponse>(ICommand<TResponse> command); 
        Task Execute(ICommand<VoidResult> command); 
    }
}
