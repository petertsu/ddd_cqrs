using CqrsDemo.Application.CQRS;

namespace CqrsDemo.Infrastructure.CQRS
{
    public interface ICommandHandlersResolver
    {
        THandler GetHandler<THandler>() where THandler : class, ICommandHandler ;
    }
}
