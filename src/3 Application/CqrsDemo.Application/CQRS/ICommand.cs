using System;

namespace CqrsDemo.Application.CQRS
{
    public interface ICommand : ICommand<VoidResult>
    {
    }

    public interface ICommand<out TResponse> : IBaseCommand
    {
    }

    public interface IBaseCommand
    {
        Guid Id { get; }
    }
}
