using AutoMapper;
using JobAggregator.Api.DTO;
using JobAggregator.Core.Entities;
using JobAggregator.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobAggregator.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrganizationsController(IOrganizationService organizationService,
                                    IMapper mapper)
    : ControllerBase
{
    // GET: api/<OrganizationController>
    [HttpGet]
    public async Task<IEnumerable<Organization>> Get()
    {
        return await organizationService.GetAllAsync();
    }

    // GET api/<OrganizationController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var organization = await organizationService.GetAsync(id);
        return organization == null ? NotFound() : Ok(organization);
    }

    // POST api/<OrganizationController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] OrganizationDTO organization)
    {
        var newOrganization = mapper.Map<Organization>(organization);
        var created = await organizationService.CreateAsync(newOrganization);
        return Ok(created);
    }

    // PUT api/<OrganizationController>/5
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] OrganizationDTO organization)
    {
        var oldOrganization = await organizationService.GetAsync(id);
        if (oldOrganization != null)
        {
            oldOrganization = mapper.Map<OrganizationDTO, Organization>(organization, oldOrganization);
            var updated = await organizationService.UpdateAsync(oldOrganization);
            return Ok(updated);
        }
        return BadRequest();
    }

    // DELETE api/<OrganizationController>/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var deleted = await organizationService.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        else
        {
            return Ok(deleted);
        }
    }
}
