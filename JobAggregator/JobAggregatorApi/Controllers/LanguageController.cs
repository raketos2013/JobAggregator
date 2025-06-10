using AutoMapper;
using JobAggregator.Api.DTO;
using JobAggregator.Core.Entities;
using JobAggregator.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobAggregator.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LanguageController(ILanguageService languageService,
                                IMapper mapper) : ControllerBase
{
    // GET: api/<LanguageController>
    [HttpGet]
    public async Task<IEnumerable<Language>> Get()
    {
        return await languageService.GetAllAsync();
    }

    // GET api/<LanguageController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var language = await languageService.GetAsync(id);
        return language == null ? NotFound() : Ok(language);
    }

    // POST api/<LanguageController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] LanguageDTO dto)
    {
        var newLanguage = mapper.Map<Language>(dto);
        var created = await languageService.CreateAsync(newLanguage);
        return Ok(created);
    }

    // PUT api/<LanguageController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] LanguageDTO dto)
    {
        var oldLanguage = await languageService.GetAsync(id);
        if (oldLanguage != null)
        {
            Language edited = mapper.Map<Language>(dto);
            edited.Id = id;
            var updated = await languageService.UpdateAsync(edited);
            return Ok(updated);
        }
        return BadRequest();

    }

    // DELETE api/<LanguageController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await languageService.DeleteAsync(id);
        if (!deleted)
        {
            return NotFound();
        }
        else
        {
            return BadRequest();
        }
    }
}
