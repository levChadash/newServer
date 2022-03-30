using AutoMapper;
using BL;
using DTO;
using Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    
    public class StudentController : ControllerBase
    {
        //try2 t = new try2();
        //Itry2 t;
        IStudentBL studentbl;
        IMapper mapper;
        public StudentController(IStudentBL studentbl, IMapper mapper/*, Itry2 t*/)
        {
            this.studentbl = studentbl;
            this.mapper = mapper;
            //this.t = t;
        }

        //STUDENT:

        //get all students (dto)
        // GET: api/<StudentController>
        //
        [HttpGet]
        public async Task<ActionResult<List<StudentDTO>>> Get()
        {

            List<Student> ls = await studentbl.GetStudents();
            if (ls == null)
            {
                return NoContent();
            }
            List<StudentDTO> lsDTO = mapper.Map<List<Student>, List<StudentDTO>>(ls);
            return lsDTO;
        }

        //get student by id (dto)
        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public async Task<StudentDTO> Get(int id)
        {
            Student s = await studentbl.GetStudentById(id);
            StudentDTO sDTO = mapper.Map<Student, StudentDTO>(s);
            return sDTO;
        }
        //get student by id number
        [HttpGet("studentId/{id}")]
        public async Task<StudentDTO> GetByStudentId(string id)
        {
            Student s = await studentbl.GetByStudentId(id);
            StudentDTO sDTO = mapper.Map<Student, StudentDTO>(s);
            return sDTO;
        }
        //get student by user id
        [HttpGet("userId/{id}")]
        public async Task<StudentDTO> getStudentByUserId(int id)
        {
            Student s = await studentbl.getStudentByUserId(id);
            StudentDTO sDTO = mapper.Map<Student, StudentDTO>(s);
            return sDTO;
        }
        // POST api/<StudentController>
        [HttpPost]
        public async Task<int> Post([FromBody] Student new_student)
        {
            return await studentbl.PostStudent(new_student);
        }

        // PUT api/<StudentController>/5
        [HttpPut]
        public async Task<StudentDTO> putStudent([FromBody] Student student)
        {
            Student s = await studentbl.PutStudent(student);
            StudentDTO sDTO = mapper.Map<Student, StudentDTO>(s);
            return sDTO;
        }
        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await studentbl.Deletestudent(id);
        }

    }
}


