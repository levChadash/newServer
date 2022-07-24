using BL;
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
   // [Authorize]
    public class ReportController : ControllerBase
    {
        IReportBL reportbl;
        public ReportController(IReportBL reportbl)
        {
            this.reportbl = reportbl;
        }
       // GET: api/<ReportController>
        [HttpGet]
        public async Task<List<Report>> Get()
        {
            return await this.reportbl.getReports();
        }

        //GET api/<ReportController>/5
        [HttpGet("{id}")]
        public async Task<Report> Get(int id)
        {
            return await this.reportbl.getReporttById(id);
        }
        //GET api/<ReportController>/5
        [HttpGet("volunteering/{id}")]
        public async Task<List<Report>> GetByVolunteerId(int id)
        {
            return await this.reportbl.getByVolunteerId(id);
        }


        //POST api/<ReportController>
        [HttpPost]
        [AllowAnonymous]
        public async Task<int> Post([FromBody] Report rt)
        {
            return await this.reportbl.postReport(rt);
        }

       // PUT api/<ReportController>/5
        [HttpPut]
        public async Task<Report> Put([FromBody] Report report)
        {
            return await this.reportbl.putReport(report);
        }

       // DELETE api/<ReportController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await this.reportbl.deleteReport(id);
        }
    }
}
