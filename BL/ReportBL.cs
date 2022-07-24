using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DL;
using Entity;

namespace BL
{
   public class ReportBL : IReportBL
    {
        IReportDL reportdl;
        public ReportBL(IReportDL reportdl)
        {
            this.reportdl = reportdl;
        }
        //delete
        public async Task deleteReport(int id)
        {
            await this.reportdl.deleteReport(id);
        }
        //get
        public async Task<List<Report>> getReports()
        {
            return await this.reportdl.getReports();
        }
        //getById
        public async Task<Report> getReporttById(int id)
        {
            return await this.reportdl.getReporttById(id);
        }
        //getByVolunteerId
        public async Task<List<Report>> getByVolunteerId(int id)
        {
            return await this.reportdl.getByVolunteerId(id);
        }
        //post
        public async Task<int> postReport(Report rt)
        {
            return await this.reportdl.postReport(rt);
        }
        //put
        public async Task<Report> putReport(Report rt)
        {
            return await this.reportdl.putReport(rt);
        }
    }
}
