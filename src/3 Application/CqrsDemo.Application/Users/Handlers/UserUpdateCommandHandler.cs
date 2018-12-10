using System.Threading.Tasks;
using CqrsDemo.Application.CQRS;
using CqrsDemo.Application.Users.Commands;

namespace CqrsDemo.Application.Users.Handlers
{
    internal class UserUpdateCommandHandler : ICommandHandler<UserUpdateCommand>
    {
        public Task<VoidResult> Execute(UserUpdateCommand command)
        {
            return Task.FromResult(default(VoidResult));
        }
    }
}
