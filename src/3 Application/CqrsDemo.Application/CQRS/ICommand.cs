using System;
using System.Collections.Generic;
using System.Text;

namespace CqrsDemo.Application.CQRS
{
    public interface ICommand
    {
        Guid Id { get; }
    }
}
