using AutoMapper;
using FluentValidation;
using JobAggregator.Api.DTO;
using JobAggregator.Core.Entities;
using JobAggregator.Core.Extensions;
using JobAggregator.Core.Interfaces.Services;
using JobAggregator.Core.Queries;
using JobAggregator.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobAggregator.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RequirementsController(IRequirementService requirementService,
                                    IMapper mapper,
                                    IValidator<HandbookDTO> validator) : ControllerBase
{
    // GET: api/<RequirementController>
    [HttpGet]
    public async Task<ActionResult<PagedList<Requirement>>> Get([FromQuery] QueryDTO queryDTO)
    {
        var query = mapper.Map<Query>(queryDTO);
        var requirements = await requirementService.GetAllAsync(query);
        var requirementsDTO = mapper.Map<List<HandbookDTO>>(requirements);
        var pagedDTO = new PagedList<HandbookDTO>(requirementsDTO, requirements.Count,
                                                        requirements.CurrentPage, requirements.PageSize);
        return Ok(pagedDTO);
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
        var validationResult = validator.Validate(dto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors[0].ToString());
        }
        var newRequirement = mapper.Map<Requirement>(dto);
        var created = await requirementService.CreateAsync(newRequirement);
        return Ok(created);
    }

    // PUT api/<RequirementController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] HandbookDTO dto)
    {
        var validationResult = validator.Validate(dto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors[0].ToString());
        }
        var oldRequirement = await requirementService.GetAsync(id);
        if (oldRequirement != null)
        {
            oldRequirement = mapper.Map<HandbookDTO, Requirement>(dto, oldRequirement);
            var updated = await requirementService.UpdateAsync(oldRequirement);
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
