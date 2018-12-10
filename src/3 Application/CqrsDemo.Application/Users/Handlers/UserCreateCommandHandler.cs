using System.Threading.Tasks;
using CqrsDemo.Application.CQRS;
using CqrsDemo.Application.Users.Commands;

namespace CqrsDemo.Application.Users.Handlers
{
    internal class UserCreateCommandHandler : ICommandHandler<UserCreateCommand, int>
    {
        public Task<int> Execute(UserCreateCommand command)
        {
            return Task.FromResult(-1);
        }
    }
}
