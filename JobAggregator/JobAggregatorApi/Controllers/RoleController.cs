using JobAggregator.Api.DTO;
using JobAggregator.Core.Entities;
using JobAggregator.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobAggregator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // TODO: дать доступ к контроллеру только роли ADMIN
    public class RoleController(IRoleService roleService) : ControllerBase
    {
        // GET: api/<RoleController>
        [HttpGet]
        public async Task<IEnumerable<Role>> Get()
        {
            return await roleService.GetAllAsync();
        }

        // GET api/<RoleController>/5
        [HttpGet("{id}")]
        public async Task<Role> Get(int id)
        {
            return await roleService.GetAsync(id);
        }

        // POST api/<RoleController>
        [HttpPost]
        public async Task<ActionResult> Create([FromBody]RoleDTO role)
        {
            Role newRole = new()
            {
                Name = role.Name
            };
            var created = await roleService.CreateAsync(newRole); 
            return Ok(created);
        }

        // PUT api/<RoleController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody]RoleDTO role)
        {
            var oldRole = roleService.GetAsync(id);
            if (oldRole == null)
            {
                Role editedRole = new()
                {
                    Id = id,
                    Name = role.Name
                };
                var updated = await roleService.UpdateAsync(editedRole);
                return Ok(updated);
            }
            return BadRequest();
        }

        // DELETE api/<RoleController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await roleService.DeleteAsync(id);
            return Ok(deleted);
        }
    }
}
