using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using DL;
using BL;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Volunteer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PesachProjectController : ControllerBase
    {
        IPesachProjectBL pesachpropject;
        public PesachProjectController(IPesachProjectBL pesachpropject)
        {
            this.pesachpropject = pesachpropject;
        }
        // service אם נרצה להשתמש צריך להוסיף ל
        //get all pesachProjects
        // GET: api/<PesachProjectController>
        //[HttpGet]
        //public async Task<ActionResult<List<PesachProject>>> Get()
        //{
        //    List<PesachProject> pesach = await pesachpropject.GetPesachProject();
        //    if (pesach == null)
        //    {
        //        return NoContent();
        //    }
        //    return pesach;
        //}
        // GET api/<PesachProjectController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PesachProject>> Get(int id)
        {
            PesachProject pesach = await pesachpropject.getPesachProjectById(id);
            if (pesach == null)
            {
                return NoContent();
            }
            return pesach;
        }

        // POST api/<PesachProjectController>
        [HttpPost]
        public async Task<int> post([FromBody] PesachProject pesach)

        {
            return await pesachpropject.postPesachProject(pesach);
        }

        // PUT api/<PesachProjectController>/5
        [HttpPut]
        public async Task<PesachProject> Put([FromBody] PesachProject pesach)
        {
            return await pesachpropject.putPesachProject(pesach);
        }

        // DELETE api/<PesachProjectController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            pesachpropject.deletePesachProject(id);
        }

    }

}
