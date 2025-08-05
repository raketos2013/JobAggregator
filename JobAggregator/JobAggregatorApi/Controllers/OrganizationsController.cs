using AutoMapper;
using JobAggregator.Api.DTO;
using JobAggregator.Core.Entities;
using JobAggregator.Core.Extensions;
using JobAggregator.Core.Interfaces.Services;
using JobAggregator.Core.Queries;
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
    public async Task<ActionResult<PagedList<Organization>>> Get([FromQuery] QueryDTO queryDTO)
    {
        var query = mapper.Map<Query>(queryDTO);
        var organizations = await organizationService.GetAllAsync(query);
        //var organizationsDTO = mapper.Map<List<OrganizationDTO>>(organizations);
        var pagedDTO = new PagedList<Organization>(organizations, organizations.Count, organizations.CurrentPage, organizations.PageSize);
        return Ok(pagedDTO);
    }

    // GET api/<OrganizationController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var organization = await organizationService.GetWithUserAsync(id);
        var organizationDTO = mapper.Map<OrganizationUsersDTO>(organization);
        foreach (var item in organization.Users)
        {
            organizationDTO.IdUsers.Add(item.Id);
        }
        return organization == null ? NotFound() : Ok(organizationDTO);
    }

    // POST api/<OrganizationController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateOrganizationDTO createOrganizationDTO)
    {
        var newOrganization = mapper.Map<Organization>(createOrganizationDTO.Organization);        
        var created = await organizationService.CreateAsync(newOrganization, createOrganizationDTO.UserId);
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

    [HttpGet("{id}/usersId")]
    public async Task<ActionResult<List<OrganizationUsersDTO>>> GetByUserId(int id)
    {
        var organizations = await organizationService.GetByUserIdAsync(id);
        List<OrganizationUsersDTO> organizationsDTO = new List<OrganizationUsersDTO>();
        foreach (var organization in organizations)
        {
            var organizationDTO = mapper.Map<OrganizationUsersDTO>(organization);
            foreach (var item in organization.Users)
            {
                organizationDTO.IdUsers.Add(item.Id);
            }
            organizationsDTO.Add(organizationDTO);
        }
                
        return organizations == null ? NotFound() : Ok(organizationsDTO);
    }
}
