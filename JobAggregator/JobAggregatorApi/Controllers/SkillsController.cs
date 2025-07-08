using AutoMapper;
using FluentValidation;
using JobAggregator.Api.DTO;
using JobAggregator.Core.Entities;
using JobAggregator.Core.Extensions;
using JobAggregator.Core.Interfaces.Services;
using JobAggregator.Core.Queries;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobAggregator.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SkillsController(ISkillService skillService,
                                IMapper mapper,
                                IValidator<HandbookDTO> validator) : ControllerBase
{
    // GET: api/<SkillController>
    [HttpGet]
    public async Task<ActionResult<PagedList<Skill>>> Get([FromQuery] QueryDTO queryDTO)
    {
        var query = mapper.Map<Query>(queryDTO);
        var skills = await skillService.GetAllAsync(query);
        var skillsDTO = mapper.Map<List<HandbookDTO>>(skills);
        var pagedDTO = new PagedList<HandbookDTO>(skillsDTO, skills.Count, skills.CurrentPage, skills.PageSize);
        return Ok(pagedDTO);
    }

    // GET api/<SkillController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var skill = await skillService.GetAsync(id);
        return skill == null ? NotFound() : Ok(skill);
    }

    // POST api/<SkillController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] HandbookDTO dto)
    {
        var validationResult = validator.Validate(dto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors[0].ToString());
        }
        var newSkill = mapper.Map<Skill>(dto);
        var created = await skillService.CreateAsync(newSkill);
        return Ok(created);
    }

    // PUT api/<SkillController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] HandbookDTO dto)
    {
        var validationResult = validator.Validate(dto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors[0].ToString());
        }
        var oldSkill = await skillService.GetAsync(id);
        if (oldSkill != null)
        {
            oldSkill = mapper.Map<HandbookDTO, Skill>(dto, oldSkill);
            var updated = skillService.UpdateAsync(oldSkill);
            return Ok(updated);
        }
        return BadRequest();

    }

    // DELETE api/<SkillController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await skillService.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        else
        {
            return Ok();
        }
    }
}
