using AutoMapper;
using JobAggregator.Api.DTO;
using JobAggregator.Core.Entities;
using JobAggregator.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobAggregator.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VacancyController(IVacancyService vacancyService,
                                IMapper mapper) : ControllerBase
{
    // GET: api/<VacancyController>
    [HttpGet]
    public async Task<IEnumerable<Vacancy>> Get()
    {
        return await vacancyService.GetAllAsync();
    }

    // GET api/<VacancyController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var vacancy = await vacancyService.GetAsync(id);
        return vacancy == null ? NotFound() : Ok(vacancy);
    }

    // POST api/<VacancyController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] VacancyDTO vacancy)
    {
        var newVacancy = mapper.Map<Vacancy>(vacancy);
        var created = await vacancyService.CreateAsync(newVacancy);
        return Ok(created);
    }

    // PUT api/<VacancyController>/5
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] VacancyDTO vacancy)
    {
        var oldVacancy = await vacancyService.GetAsync(id);
        if (oldVacancy != null)
        {
            oldVacancy = mapper.Map<VacancyDTO, Vacancy>(vacancy, oldVacancy);
            var updated = await vacancyService.UpdateAsync(oldVacancy);
            return Ok(updated);
        }
        return BadRequest();
    }

    // DELETE api/<VacancyController>/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var deleted = await vacancyService.DeleteAsync(id);
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
