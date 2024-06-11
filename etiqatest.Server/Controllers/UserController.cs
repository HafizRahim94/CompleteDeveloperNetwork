using etiqatest.Application.Auth.Login;
using etiqatest.Application.Users.User.AddSkillset;
using etiqatest.Application.Users.User.AddUser;
using etiqatest.Application.Users.User.DeleteSkillset;
using etiqatest.Application.Users.User.DeleteUser;
using etiqatest.Application.Users.User.GetSkillsets;
using etiqatest.Application.Users.User.GetUser;
using etiqatest.Application.Users.User.GetUsers;
using etiqatest.Application.Users.User.UpdateSkillset;
using etiqatest.Application.Users.User.UpdateUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace etiqatest.Server.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/[controller]")]
    public class UserController(IMediator mediator) : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            var result = await mediator.Send(command);

            return Ok(result);
        }

        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var query = new GetUsersQuery();

            var result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser([FromQuery] int userId)
        {
            var query = new GetUserQuery(userId);
            var result = await mediator.Send(query);

            return Ok(result);
        }

        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser([FromBody] AddUserCommand command)
        {
            var result = await mediator.Send(command);

            return Ok(result);
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand command)
        {
            var result = await mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("DeleteUser")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            var command = new DeleteUserCommand
            {
                UserId = userId
            };

            var result = await mediator.Send(command);

            return Ok(result);
        }

        [HttpPost("AddSkillset")]
        public async Task<IActionResult> AddSkillset([FromBody] AddSkillsetCommand command)
        {
            var result = await mediator.Send(command);

            return Ok(result);
        }

        [HttpPost("GetSkillset")]
        public async Task<IActionResult> GetSkillset()
        {
            return Ok();
        }

        [HttpGet("GetSkillsets")]
        public async Task<IActionResult> GetSkillsets([FromQuery] int userId)
        {
            var command = new GetSkillsetsCommand()
            {
                UserId = userId
            };
            var result = await mediator.Send(command);

            return Ok(result);
        }

        [HttpPut("UpdateSkillset")]
        public async Task<IActionResult> UpdateSkillset([FromBody] UpdateSkillsetCommand command)
        {
            var result = await mediator.Send(command);

            return Ok(result);
        }

        [HttpDelete("DeleteSkillset")]
        public async Task<IActionResult> DeleteSkillset([FromQuery] int skillsetId)
        {
            var command = new DeleteSkillsetCommand
            {
                SkillsetId = skillsetId
            };

            var result = await mediator.Send(command);

            return Ok(result);
        }
    }
}
