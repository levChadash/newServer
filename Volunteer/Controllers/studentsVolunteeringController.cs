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
    public class studentsVolunteeringController : ControllerBase
    {
        IstudentsVolunteeringBL studentsvolunteeringbl;
        public studentsVolunteeringController(IstudentsVolunteeringBL studentsvolunteeringbl)
        {
            this.studentsvolunteeringbl = studentsvolunteeringbl;
        }
        // GET: api/<studentsVolunteeringController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<studentsVolunteeringController>/5
        [HttpGet("{id}")]
        public async Task<StudentsVolunteering> GetByStudentId(int id)
        {
          return await studentsvolunteeringbl.GetByStudentId(id);
        }

        // POST api/<studentsVolunteeringController>
        [HttpPost]
        public async Task<int> Post([FromBody] StudentsVolunteering studentsVolunteering)
        {
            return await studentsvolunteeringbl.post(studentsVolunteering);
        }

        // PUT api/<studentsVolunteeringController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<studentsVolunteeringController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await this.studentsvolunteeringbl.delete(id);
        }
    }
}
