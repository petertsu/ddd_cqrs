using CqrsDemo.Application.CQRS;
using CqrsDemo.Infrastructure.CQRS;
using SimpleInjector;

namespace CqrsDemo.Host.CQRS
{
    public class SimpleInjectorCommandHandlersResolver : ICommandHandlersResolver
    {
        private readonly Container _ioc;

        public SimpleInjectorCommandHandlersResolver(Container ioc)
        {
            _ioc = ioc;
        }

        public THandler GetHandler<THandler>() where THandler : class, ICommandHandler
        {
            return _ioc.GetInstance<THandler>();
        }
    }
}
