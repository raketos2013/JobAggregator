using AutoMapper;
using JobAggregator.Api.DTO;
using JobAggregator.Core.Entities;
using JobAggregator.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JobAggregator.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OfferController(IOfferService offerService,
                                IMapper mapper) : ControllerBase
{
    // GET: api/<OfferController>
    [HttpGet]
    public async Task<IEnumerable<Offer>> Get()
    {
        return await offerService.GetAllAsync();
    }

    // GET api/<OfferController>/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var offer = await offerService.GetAsync(id);
        return offer == null ? NotFound() : Ok(offer);
    }

    // POST api/<OfferController>
    [HttpPost]
    public async Task<IActionResult> Post([FromBody] HandbookDTO dto)
    {
        var newOffer = mapper.Map<Offer>(dto);
        var created = await offerService.CreateAsync(newOffer);
        return Ok(created);
    }

    // PUT api/<OfferController>/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] HandbookDTO dto)
    {
        var oldOffer = await offerService.GetAsync(id);
        if (oldOffer != null)
        {
            Offer edited = mapper.Map<Offer>(dto);
            edited.Id = id;
            var updated = await offerService.UpdateAsync(edited);
            return Ok(updated);
        }
        return BadRequest();
    }

    // DELETE api/<OfferController>/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await offerService.DeleteAsync(id);
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
