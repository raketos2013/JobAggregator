using AutoMapper;
using JobAggregator.Api.DTO;
using JobAggregator.Core.Entities;
using JobAggregator.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobAggregator.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
// TODO: дать доступ к контроллеру только роли ADMIN
public class RoleController(IRoleService roleService,
                            IMapper mapper) : ControllerBase
{
    // GET: api/<RoleController>
    [HttpGet]
    public async Task<IEnumerable<Role>> Get()
    {
        return await roleService.GetAllAsync();
    }

    // GET api/<RoleController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var role = await roleService.GetAsync(id);
        return role == null ? NotFound() : Ok(role);
    }

    // POST api/<RoleController>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] RoleDTO role)
    {
        var newRole = mapper.Map<Role>(role);
        var created = await roleService.CreateAsync(newRole);
        return Ok(created);
    }

    // PUT api/<RoleController>/5
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, [FromBody] RoleDTO role)
    {
        var oldRole = roleService.GetAsync(id);
        if (oldRole != null)
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
