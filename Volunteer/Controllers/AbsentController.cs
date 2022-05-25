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
    public class AbsentController : ControllerBase
    {
        IAbsentBL absentbl;

        public AbsentController(IAbsentBL absentbl)
        {
            this.absentbl = absentbl;

        }
        // GET: api/<AbsentController>
        [HttpGet]
        public async Task<ActionResult<List<Absent>>> Get()
        {
            List<Absent> lA = await absentbl.Get();
            if (lA == null)
            {
                return NoContent();
            }
          
            return lA;
        }




        // POST api/<AbsentController>
        [HttpPost]
        public async Task<int> Post([FromBody] Absent abs)
        {
            return await absentbl.postAbsent(abs);
        }

        // PUT api/<AbsentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AbsentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
