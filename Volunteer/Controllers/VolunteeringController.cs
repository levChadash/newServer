using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using BL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Volunteer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolunteeringController : ControllerBase
    {
        IVolunteeringBL volunteeringbl;
        public VolunteeringController(IVolunteeringBL registerbl)
        {
            this.volunteeringbl = registerbl;
        }
        // GET: api/<RegisterController>
        [HttpGet]
        public async Task<List<Volunteering>> Get()
        {
            return await volunteeringbl.GetRegister();
        }
        //[HttpGet]
      
        // GET api/<RegisterController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<RegisterController>
        [HttpPost]
        public async Task<int> Post([FromBody] Volunteering rg)
        {
           return await volunteeringbl.postRegister(rg);
        }

        // PUT api/<RegisterController>/5
        [HttpPut]
        public async Task<Volunteering> Put([FromBody] Volunteering rg)
        {
            return await volunteeringbl.putRegister(rg);
        }

        // DELETE api/<RegisterController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await volunteeringbl.deleteRegister(id);
        }
    }
}

