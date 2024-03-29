﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BL;
using Entity;
using AutoMapper;
using DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Volunteer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class studentsVolunteeringController : ControllerBase
    {
        IstudentsVolunteeringBL studentsvolunteeringbl;
        IMapper mapper;
        public studentsVolunteeringController(IstudentsVolunteeringBL studentsvolunteeringbl, IMapper mapper)
        {
            this.studentsvolunteeringbl = studentsvolunteeringbl;
            this.mapper = mapper;
        }
        // GET: api/<studentsVolunteeringController>
        [HttpGet]
        public async Task<ActionResult<List<StudentVolunteeringDTO>>> Get()
        {
            List<StudentsVolunteering> slv = await studentsvolunteeringbl.Get();
            if (slv == null)
            {
                return NoContent();
            }
            List<StudentVolunteeringDTO> slvDTO = mapper.Map<List<StudentsVolunteering>, List<StudentVolunteeringDTO>>(slv);
            return slvDTO;
        }

        // GET api/<studentsVolunteeringController>/5
        //[HttpGet("{id}")]
        //public async Task<StudentsVolunteering> GetByStudentId(int id)
        //{
        //  return await studentsvolunteeringbl.GetByStudentId(id);
        //}
        [HttpGet("{volunteeringId}")]

        public async Task<ActionResult<List<StudentVolunteeringDTO>>> GetByVolunteeringId(int volunteeringId)
        {
        List<StudentsVolunteering> slv = await studentsvolunteeringbl.GetByVolunteeringId(volunteeringId);
        if (slv == null)
        {
            return NoContent();
        }
        List<StudentVolunteeringDTO> slvDTO = mapper.Map<List<StudentsVolunteering>, List<StudentVolunteeringDTO>>(slv);
        return slvDTO;
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
