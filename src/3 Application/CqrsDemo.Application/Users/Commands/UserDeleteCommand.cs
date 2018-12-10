using System;
using CqrsDemo.Application.CQRS;

namespace CqrsDemo.Application.Users.Commands
{
    public class UserDeleteCommand : ICommand
    {
        public UserDeleteCommand(int userId)
        {
            Id = Guid.NewGuid();
            UserId = userId;
        }
        public Guid Id { get; }
        public int UserId { get; }
    }
}
