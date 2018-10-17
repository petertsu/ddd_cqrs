using System;
using CqrsDemo.Application.CQRS;

namespace CqrsDemo.Application.Users
{
    public class UserCreateCommand : ICommand<int>
    {
        public UserCreateCommand(string firstname, string lastname)
        {
            Id = Guid.NewGuid();
            FirstName = firstname;
            LastName = lastname;
        }
        public Guid Id { get; }
        public string FirstName  { get; }
        public string LastName  { get; }

    }
}
