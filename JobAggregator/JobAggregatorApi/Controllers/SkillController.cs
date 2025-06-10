using AutoMapper;
using JobAggregator.Api.DTO;
using JobAggregator.Core.Entities;
using JobAggregator.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobAggregator.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SkillController(ISkillService skillService,
                                IMapper mapper) : ControllerBase
{
    // GET: api/<SkillController>
    [HttpGet]
    public async Task<IEnumerable<Skill>> Get()
    {
        return await skillService.GetAllAsync();
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
        var newSkill = mapper.Map<Skill>(dto);
        var created = await skillService.CreateAsync(newSkill);
        return Ok(created);
    }

    // PUT api/<SkillController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] HandbookDTO dto)
    {
        var oldSkill = await skillService.GetAsync(id);
        if (oldSkill != null)
        {
            Skill edited = mapper.Map<Skill>(dto);
            edited.Id = id;
            var updated = skillService.UpdateAsync(edited);
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
