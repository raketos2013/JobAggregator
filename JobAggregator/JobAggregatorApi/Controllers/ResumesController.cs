using AutoMapper;
using FluentValidation;
using JobAggregator.Api.DTO;
using JobAggregator.Core.Entities;
using JobAggregator.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobAggregator.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ResumesController(IResumeService resumeService,
                                IMapper mapper,
                                IValidator<ResumeDTO> validator) : ControllerBase
{
    // GET: api/<ResumeController>
    [HttpGet]
    public async Task<IEnumerable<Resume>> Get()
    {
        return await resumeService.GetAllAsync();
    }

    // GET api/<ResumeController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var resume = await resumeService.GetAsync(id);
        return resume == null ? NotFound() : Ok(resume);
    }

    // POST api/<ResumeController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] ResumeDTO resume)
    {
        var validationResult = validator.Validate(resume);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors[0].ToString());
        }
        var newResume = mapper.Map<Resume>(resume);
        var created = await resumeService.CreateAsync(newResume);
        return Ok(created);
    }

    // PUT api/<ResumeController>/5
    [HttpPut("{id}")]
    public async Task<ActionResult> Put(int id, [FromBody] ResumeDTO resume)
    {
        var validationResult = validator.Validate(resume);
        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors[0].ToString());
        }
        var oldResume = await resumeService.GetAsync(id);
        if (oldResume != null)
        {
            oldResume = mapper.Map<ResumeDTO, Resume>(resume, oldResume);
            var updated = await resumeService.UpdateAsync(oldResume);
            return Ok(updated);
        }
        return BadRequest();
    }

    // DELETE api/<ResumeController>/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var deleted = await resumeService.DeleteAsync(id);
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
