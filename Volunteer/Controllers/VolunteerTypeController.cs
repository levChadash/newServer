using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Entity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Volunteer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolunteerTypeController : ControllerBase
    {
        IVolunteerTypeBL volunteertypebl;
        public VolunteerTypeController(IVolunteerTypeBL volunteertypebl)
        {
            this.volunteertypebl = volunteertypebl;
        }
        // GET: api/<VolunteerTypeController>
        [HttpGet]
        public Task<List<VolunteerType>> Get()
        {
            return this.volunteertypebl.getVolunteerTypes();
        }

        // GET api/<VolunteerTypeController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<VolunteerTypeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<VolunteerTypeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<VolunteerTypeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
