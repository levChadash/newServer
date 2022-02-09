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
    public class RegisterController : ControllerBase
    {
        IRegisterBL registerbl;
        public RegisterController(IRegisterBL registerbl)
        {
            this.registerbl = registerbl;
        }
        // GET: api/<RegisterController>
        [HttpGet]
        public async Task<List<Register>> Get()
        {
            return await registerbl.GetRegister();
        }

        // GET api/<RegisterController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<RegisterController>
        [HttpPost]
        public async Task<int> Post([FromBody] Register rg)
        {
           return await registerbl.postRegister(rg);
        }

        // PUT api/<RegisterController>/5
        [HttpPut]
        public async Task<Register> Put([FromBody] Register rg)
        {
            return await registerbl.putRegister(rg);
        }

        // DELETE api/<RegisterController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await registerbl.deleteRegister(id);
        }
    }
}

