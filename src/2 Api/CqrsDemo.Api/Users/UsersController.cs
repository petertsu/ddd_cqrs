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
        public async  Task<IActionResult> Post()
        {
            var userCreateCommand = new UserCreateCommand("","");

            await _commandDispather.Execute(userCreateCommand);

            return Ok();

            //  return Created(Url.Action("GetById", ControllerContext.ActionDescriptor.ControllerName, userCreateCommand.Id ), null);
        }

        [HttpGet("{id}")]
        public async  Task<IActionResult> GetById(string id)
        {
            await Task.Delay(1);

            return Ok();
        }

        [HttpGet]
        public async  Task<IActionResult> Get()
        {
            await Task.Delay(1);

            return Ok("Get");
        }
    }
}
