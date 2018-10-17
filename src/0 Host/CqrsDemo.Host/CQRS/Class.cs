using System.Threading.Tasks;
using CqrsDemo.Application.CQRS;
using Microsoft.Extensions.DependencyInjection;
using SimpleInjector;

namespace CqrsDemo.Host.CQRS
{
    internal abstract class RequestHandlerBase
    {
        protected Container Ioc;

        protected RequestHandlerBase(Container ioc)
        {
            Ioc = ioc;
        }
        protected THandler GetHandler<THandler>()
        {
            return Ioc.GetRequiredService<THandler>();
        }
    }

    internal abstract class RequestHandlerWrapper<TResponse> : RequestHandlerBase
    {
        public abstract Task<TResponse> Handle(ICommand<TResponse> request);

        protected RequestHandlerWrapper(Container ioc) : base(ioc)
        {
        }
    }

    internal class RequestHandlerWrapperImpl<TRequest, TResponse> : RequestHandlerWrapper<TResponse>
        where TRequest : ICommand<TResponse>
    {
        public override Task<TResponse> Handle(ICommand<TResponse> request)
        {
            var h = GetHandler<ICommandHandler<TRequest, TResponse>>();

            return h.Execute((TRequest)request);
        }

        public RequestHandlerWrapperImpl(Container ioc) : base(ioc)
        {
        }
    }

}
