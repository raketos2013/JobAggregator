using JobAggregator.Core.Entities;
using JobAggregator.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace JobAggregator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController(IOrganizationService organizationService) 
        : ControllerBase
    {
        // GET: api/<OrganizationController>
        [HttpGet]
        public async Task<IEnumerable<Organization>> Get()
        {
            return await organizationService.GetAllAsync();
        }

        // GET api/<OrganizationController>/5
        [HttpGet("{id}")]
        public async Task<Organization> Get(int id)
        {
            return await organizationService.GetAsync(id);
        }

        // POST api/<OrganizationController>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<OrganizationController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<OrganizationController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
