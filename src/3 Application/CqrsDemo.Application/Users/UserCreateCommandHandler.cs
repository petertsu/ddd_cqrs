using System.Threading.Tasks;
using CqrsDemo.Application.CQRS;

namespace CqrsDemo.Application.Users
{
    internal class UserCreateCommandHandler : ICommandHandler<UserCreateCommand>
    {
        public Task Execute(UserCreateCommand command)
        {
            return Task.FromResult(0);
        }
    }
}
