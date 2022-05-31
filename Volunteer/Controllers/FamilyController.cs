using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Entity;
using AutoMapper;
using DTO;
using Microsoft.AspNetCore.Authorization;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Volunteer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    

    public class FamilyController : ControllerBase
    {

        IFamilyBL familybl;
        IMapper mapper;
        public FamilyController(IFamilyBL familybl, IMapper mapper)
        {
            this.mapper = mapper;
            this.familybl = familybl;
        }

        //FAMILY

        //get all families (dto)
        // GET: api/<FamilyController>
        [HttpGet]
        public async Task<ActionResult<List<FamilyDTO>>> Get()
        {
            List<Family> lf = await familybl.GetFamilies();
            if (lf == null)
            {
                return NoContent();
            }
            List<FamilyDTO> lfDTO = mapper.Map<List<Family>, List<FamilyDTO>>(lf);
            return lfDTO;
        }

        [HttpGet ("notSet")]
        public async Task<ActionResult<List<FamilyDTO>>> GetnotSetFamilys()
        {
            List<Family> lf = await familybl.GetNotSetFamilies();
            if (lf == null)
            {
                return NoContent();
            }
            List<FamilyDTO> lfDTO = mapper.Map<List<Family>, List<FamilyDTO>>(lf);
            return lfDTO;
        }

        //get family by id
        // GET api/<FamilyController>/5
        [HttpGet("{id}")]
        public  async Task<FamilyDTO> Get(int id)
        {
            Family f= await familybl.GetFamilyById(id);
            FamilyDTO fDTO = mapper.Map<Family, FamilyDTO>(f);
            return fDTO;
        }
        //post family
        // POST api/<FamilyController>
        [HttpPost]
        public  async Task<int> Post([FromBody] Family new_family)
        {
            return await familybl.PostFamily(new_family);
        }
    
        //put family
        // PUT api/<FamilyController>/5
        [HttpPut]
        //("{id}")
       public async Task<Family> Put( [FromBody] Family family)
       {
            Family f= await familybl.PutFamily(family);
            //FamilyDTO fDTO = mapper.Map<Family, FamilyDTO>(f);
            return f;
       }
        //delete family
        // DELETE api/<FamilyController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await familybl.DeleteFamily(id);

        }

    }
}
