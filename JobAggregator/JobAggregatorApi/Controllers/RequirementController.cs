﻿using AutoMapper;
using JobAggregator.Api.DTO;
using JobAggregator.Core.Entities;
using JobAggregator.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobAggregator.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RequirementController(IRequirementService requirementService,
                                    IMapper mapper) : ControllerBase
{
    // GET: api/<RequirementController>
    [HttpGet]
    public async Task<IEnumerable<Requirement>> Get()
    {
        return await requirementService.GetAllAsync();
    }

    // GET api/<RequirementController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var requirement = await requirementService.GetAsync(id);
        return requirement == null ? NotFound() : Ok(requirement);
    }

    // POST api/<RequirementController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] HandbookDTO dto)
    {
        var newRequirement = mapper.Map<Requirement>(dto);
        var created = await requirementService.CreateAsync(newRequirement);
        return Ok(created);
    }

    // PUT api/<RequirementController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] HandbookDTO dto)
    {
        var oldRequirement = await requirementService.GetAsync(id);
        if (oldRequirement != null)
        {
            Requirement edited = mapper.Map<Requirement>(dto);
            edited.Id = id;
            var updated = await requirementService.UpdateAsync(edited);
            return Ok(updated);
        }
        return BadRequest();
    }

    // DELETE api/<RequirementController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await requirementService.DeleteAsync(id);
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
