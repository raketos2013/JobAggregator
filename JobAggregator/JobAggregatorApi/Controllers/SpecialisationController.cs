using AutoMapper;
using JobAggregator.Api.DTO;
using JobAggregator.Core.Entities;
using JobAggregator.Core.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobAggregator.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SpecialisationController(SpecialisationService specialisationService,
                                        IMapper mapper) : ControllerBase
{
    // GET: api/<SpecialisationController>
    [HttpGet]
    public async Task<IEnumerable<Specialisation>> Get()
    {
        return await specialisationService.GetAllAsync();
    }

    // GET api/<SpecialisationController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var specialisation = await specialisationService.GetAsync(id);
        return specialisation == null ? NotFound() : Ok(specialisation);
    }

    // POST api/<SpecialisationController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] HandbookDTO dto)
    {
        var newSpecialisation = mapper.Map<Specialisation>(dto);
        var created = await specialisationService.CreateAsync(newSpecialisation);
        return Ok(created);
    }

    // PUT api/<SpecialisationController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] HandbookDTO dto)
    {
        var oldSpecialisation = await specialisationService.GetAsync(id);
        if (oldSpecialisation != null)
        {
            Specialisation edited = mapper.Map<Specialisation>(dto);
            edited.Id = id;
            var updated = specialisationService.UpdateAsync(edited);
            return Ok(updated);
        }
        return BadRequest();
    }

    // DELETE api/<SpecialisationController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await specialisationService.DeleteAsync(id);
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
