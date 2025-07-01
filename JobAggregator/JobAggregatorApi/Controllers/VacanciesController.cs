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
public class VacanciesController(IVacancyService vacancyService,
                                IMapper mapper,
                                IValidator<VacancyDTO> validator) : ControllerBase
{
    // GET: api/<VacancyController>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Vacancy>>> Get([FromQuery] QueryDTO queryDTO)
    {
        var query = mapper.Map<Query>(queryDTO);
        var vacancies = await vacancyService.GetAllAsync(query);
        var pagedDTO = new PagedList<Vacancy>(vacancies, vacancies.Count, vacancies.CurrentPage, vacancies.PageSize);
        return Ok(pagedDTO);
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
        var validationResult = await validator.ValidateAsync(vacancy);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors[0].ToString());
        }
        var newVacancy = mapper.Map<Vacancy>(vacancy);
        var created = await vacancyService.CreateAsync(newVacancy);
        var createdDTO = mapper.Map<VacancyDTO>(created);
        return Ok(createdDTO);
    }

    // PUT api/<VacancyController>/5
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] VacancyDTO vacancy)
    {
        var validationResult = validator.Validate(vacancy);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors[0].ToString());
        }
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
