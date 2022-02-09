using BL;
using Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Volunteer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MatchController : ControllerBase
    {
        IMatchBL matchbl;
        public MatchController(IMatchBL matchbl)
        {
            this.matchbl = matchbl;
        }
        // GET: api/<Match>
        [HttpGet]
        public async Task<List<Match>> Get()
        {
            List<Match> lf = await matchbl.GetMatches();
            return lf;
        }

        // GET api/<Match>/5
        [HttpGet("{id}")]
        public async Task<Match> Get(int id)
        {
            return await matchbl.GetMatchByFamilyId(id);
        }
        // GET api/<Match>/5
      
        [HttpGet("match/{id}")]
        public async Task<List<Match>> GetMatchByStudentId(int id)
        {
            return await matchbl.GetMatchByStudentId(id);
        }
        [HttpGet("{family}")]
        public async Task<List<Register>> GetStudentToMatch(Family family)
        {
            return await matchbl.GetStudentToMatch(family);
        }

        // POST api/<Match>
        [HttpPost]
        public async Task<int> PostAsync([FromBody] Match match)
        {
            return await matchbl.postMatch(match);
        }

        // PUT api/<Match>/5
        [HttpPut("{id}")]
        public async Task<Match> Put(int id, [FromBody] Match match)
        {
            return await matchbl.putMatch(match);
        }

        // DELETE api/<Match>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
           await matchbl.deleteMatch(id);
        }
    }
}
