using AutoMapper;
using FluentValidation;
using JobAggregator.Api.DTO;
using JobAggregator.Core.Entities;
using JobAggregator.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobAggregator.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ResponsibilitiesController(IResponsibilityService responsibilityService,
                                        IMapper mapper,
                                        IValidator<HandbookDTO> validator) : ControllerBase
{
    // GET: api/<ResponsibilityController>
    [HttpGet]
    public async Task<IEnumerable<Responsibility>> Get()
    {
        return await responsibilityService.GetAllAsync();
    }

    // GET api/<ResponsibilityController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var responsibility = await responsibilityService.GetAsync(id);
        return responsibility == null ? NotFound() : Ok(responsibility);
    }

    // POST api/<ResponsibilityController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] HandbookDTO dto)
    {
        var validationResult = validator.Validate(dto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors[0].ToString());
        }
        var newResponsibility = mapper.Map<Responsibility>(dto);
        var created = await responsibilityService.CreateAsync(newResponsibility);
        return Ok(created);
    }

    // PUT api/<ResponsibilityController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] HandbookDTO dto)
    {
        var validationResult = validator.Validate(dto);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors[0].ToString());
        }
        var oldResponsibility = responsibilityService.GetAsync(id).Result;
        if (oldResponsibility != null)
        {
            oldResponsibility = mapper.Map<HandbookDTO, Responsibility>(dto, oldResponsibility);
            var updated = await responsibilityService.UpdateAsync(oldResponsibility);
            return Ok(updated);
        }
        return BadRequest();
    }

    // DELETE api/<ResponsibilityController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await responsibilityService.DeleteAsync(id);
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
