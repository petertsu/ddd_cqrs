using System;
using CqrsDemo.Application.CQRS;


namespace CqrsDemo.Application.Users
{
    public class UserDeleteCommand : ICommand<VoidResult>
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
