using AutoMapper;
using BL;
using DTO;
using Entity;
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
        Itry2 t;
        IStudentBL studentbl;
        IMapper mapper;
        public StudentController(IStudentBL studentbl, IMapper mapper, Itry2 t)
        {
            this.studentbl = studentbl;
            this.mapper = mapper;
            this.t = t;
        }

        //STUDENT:

        //get all students (dto)
        // GET: api/<StudentController>
        //<ActionResult<List<StudentDTO>>>
        [HttpGet]
        public async Task Get()
        {
            await t.aa();
            //List<Student> ls = await studentbl.GetStudents();
            //if (ls == null)
            //{
            //    return NoContent();
            //}
            //List<StudentDTO> lsDTO = mapper.Map<List<Student>, List<StudentDTO>>(ls);
            //return lsDTO;
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



        //PERSON:

        // GET api/<StudentController>person

        [HttpGet("person/{id}")]
        public async Task<Person> GetPerson(int id)
        {
            return await studentbl.GetPersonById(id);
        }

        //get person by idNumber (dto)
        // GET api/<StudentController>/"324103357"
        [HttpGet("{idNum}")]
        public async Task<Person> Get(string idNum)
        {
            Person p = await studentbl.GetPersonByIdNumber(idNum);

            return p;
        }

        // POST api/<StudentController> person
  
        [HttpPost("person")]
        public async Task<int> PostPerson([FromBody] Person new_person)
        {

            return await studentbl.PostPerson(new_person);
        }

        // DELETE api/<StudentController> person

        [HttpDelete ("person/{id}")]
        public async Task DeletePerson(int id)
        {
            await studentbl.DeletePersont(id);
        }

        //STUDENT YEARS:


        // GET api/<StudentController>studentYears
       
        [HttpGet("studentYear/{id}")]
        public async Task<StudentYear> GetStudentYear(int id)
        {
            return await studentbl.GetStudentYearstById(id);
        }

        // POST api/<StudentController> studentYears
        
        [HttpPost("studentYear")]
        public async Task<int> PostStudentYears([FromBody] StudentYear new_studentyear)
        {

            return await studentbl.PostStudentYears(new_studentyear);
        }

        // DELETE api/<StudentController> StudentYear
        
        [HttpDelete("studentYear/{id}")]
        public async Task DeleteStudentYear(int id)
        {
            await studentbl.DeleteStudentYears(id);
        }

        [HttpDelete]
        public async Task Delete()
        {
            await studentbl.Delete();
        }
        [HttpPost("UploadingAStudentFile/"), DisableRequestSizeLimit]
        public async Task UploadingAStudentFile([FromForm] IFormFile StudentFile)
        {
           
            //t.aa(StudentFile);
        }
    }
}


