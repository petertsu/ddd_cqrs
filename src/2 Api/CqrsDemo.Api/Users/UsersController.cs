using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using CqrsDemo.Application.CQRS;
using CqrsDemo.Application.Users;

namespace CqrsDemo.Api.Users
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ICommandDispatcher _commandDispather;

        public UsersController(ICommandDispatcher commandDispather)
        {
            _commandDispather = commandDispather;
        }


        [HttpPost]
        public async Task<IActionResult> Post()
        {
            var userCreateCommand = new UserCreateCommand("", "");

            var createdUserId = await _commandDispather.Execute(userCreateCommand);

            return Ok(createdUserId);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int userId)
        {
            var userDeleteCommand = new UserDeleteCommand(userId);

            await _commandDispather.Execute(userDeleteCommand);

            return NoContent();
        }
    }
}