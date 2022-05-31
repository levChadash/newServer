using BL;
using DTO;
using Entity;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class UserController : ControllerBase
    {
        IUserBL Userbl;
        IStudentBL studentbl;
        IstudentsVolunteeringBL studentsvolunteeringbl;
        public UserController(IUserBL Userbl, IStudentBL studentbl, IstudentsVolunteeringBL studentsvolunteeringbl)
        {
            this.Userbl = Userbl;
            this.studentbl = studentbl;
            this.studentsvolunteeringbl = studentsvolunteeringbl;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LoginController>
        [HttpPost]
        [AllowAnonymous]
        public async Task<User> Post([FromBody] User user)
        {
            return await Userbl.AddUser(user);
        }

        // POST api/<UserController>

        [HttpPost("logIn")]
        [AllowAnonymous]
        public async Task<UserDTO> Post([FromBody] LoginDTO ldto)
        {
            UserDTO uDTO = new UserDTO();
            User u= await Userbl.GetUser(ldto.IdNumber, ldto.Password);
            if (u == null)
                return uDTO;
            uDTO.Id = u.Id;
            uDTO.IdNumber = u.IdNumber;
            uDTO.IsAdmin = u.IsAdmin;
            uDTO.Name = u.Name;
            uDTO.PhoneNumber = u.PhoneNumber;
            uDTO.CellphoneNumber = u.CellphoneNumber;
            if (u.IsAdmin)
                return uDTO;
            Student s = await studentbl.getStudentByUserId(u.Id);
            if (s!=null)
            {
                uDTO.StudentId = s.Id;
                //uDTO.GradeNum = s.Grade.GradeNum;
              //  uDTO.StartYear = s.Grade.StartYear;
                uDTO.IsVolunteer = s.IsVolunteer;
                uDTO.ClassNum = s.ClassNum;
            }
            //if (s.IsVolunteer == false)
            //    return uDTO;
            StudentsVolunteering stv = await studentsvolunteeringbl.GetByStudentId(s.Id);
            if (stv != null)
            {
                uDTO.StudentVolunteeringId = stv.Id;
                uDTO.VolunteeringId = stv.VolunteeringId;
                //uDTO.VolunteerType = stv.Volunteering.VolunteerType.Type;
                //uDTO.Neihborhood = stv.Volunteering.Neihborhood;
            }

            return uDTO;



        }


        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
