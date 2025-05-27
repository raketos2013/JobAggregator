using AutoMapper;
using JobAggregator.Api.DTO;
using JobAggregator.Core.Entities;
using JobAggregator.Core.Enum;
using JobAggregator.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobAggregator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService,
                                IMapper mapper) : ControllerBase
    {
        // TODO: доступ только роли ADMIN
        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await userService.GetAllAsync();
        }

        // TODO: доступ только роли ADMIN
        // GET: api/<UserController>/1
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> Get(int id)
        {
            return await userService.GetAsync(id);
        }

        // POST api/User
        [HttpPost]
        public async Task<ActionResult<User>> Create([FromBody] UserDTO user)
        {
            var newUser = mapper.Map<User>(user);
            var created = await userService.CreateAsync(newUser);
            return Ok(created);
        }

        // TODO: доступ только авторизованным пользователям и проверку изменять только свой аккаунт
        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UserDTO user)
        {
            var oldUser = await userService.GetAsync(id);
            if (oldUser != null)
            {
                var editedUser = mapper.Map<User>(oldUser);
                editedUser.Id = id;
                var updated = await userService.UpdateAsync(editedUser);
                return Ok(updated);
            }
            return BadRequest();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            // TODO: добавить проверку, удалять только самого себя, либо ADMIN
            var deleted = await userService.DeleteAsync(id);
            return Ok(deleted);
        }


        // PUT api/<UserController>/5
        [HttpPut("Block/{id}")]
        public async Task<ActionResult> Block(int id)
        {
            User user = await userService.GetAsync(id);
            if (user != null)
            {
                user.Status = UserStatus.Blocked;
                var updated = await userService.UpdateAsync(user);
                return Ok(updated);
            }
            return BadRequest();
        }
    }
}
