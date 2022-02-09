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
    public class AdminsController : ControllerBase
    {
        IAdminBL adminbl;
        public AdminsController(IAdminBL adminbl)
        {
            this.adminbl = adminbl;
        }
        // GET: api/<AdminsController>
        [HttpGet]
        public async Task<List<Admin>> Get()
        {
            List<Admin> lf = await adminbl.GetAdmins();
            return lf;
        }
        //service אם נרצה להשתמש בפונקציה זו צריך להוסיף גם ב
        // GET api/<AdminsController>/5
        //[HttpGet("{id}")]
        //public async Task<Admin> Get(int id)
        //{
        //    return await adminbl.GetAdminById(id);
        //}
        // GET api/<StudentController>/"324103357"
        [HttpGet("{idNum}")]
        public async Task<Admin> Get(string idNum)
        {
            return await adminbl.GetAdmintByIdNumber(idNum);
        }
        // POST api/<AdminsController>
        [HttpPost]
        public async Task<int> PostAdmin([FromBody] Admin new_admin)
        {

            return await adminbl.PostAdmin(new_admin);
        }

        // PUT api/<AdminsController>/5
        [HttpPut]
        public async Task<Admin> putAdmin([FromBody] Admin admin)
        {
            return await adminbl.PutAdmin(admin);
        }
        //service אם נרצה להשתמש בפונקציה זו צריך להוסיף גם ב
        // DELETE api/<AdminsController>/5
        //[HttpDelete("{id}")]
        //public async Task Delete(int id)
        //{
        //    await adminbl.DeleteAdmin(id);
        //}
    }
}
