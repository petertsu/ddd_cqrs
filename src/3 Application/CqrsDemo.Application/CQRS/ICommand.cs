using System;

namespace CqrsDemo.Application.CQRS
{
    public interface IBaseCommand
    {
        Guid Id { get; }
    }

    public interface ICommand<out TResponse> : IBaseCommand
    {
    }

    public interface ICommand : ICommand<VoidResult>
    {
    }
}

