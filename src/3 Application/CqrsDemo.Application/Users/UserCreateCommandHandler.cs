using System.Threading;
using System.Threading.Tasks;
using CqrsDemo.Application.CQRS;

namespace CqrsDemo.Application.Users
{
    internal class UserCreateCommandHandler : ICommandHandler<UserCreateCommand, int>
    {
        public Task<int> Execute(UserCreateCommand command)
        {
            return Task.FromResult(-1);
        }
    }
}
