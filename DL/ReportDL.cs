using DotLiquid.Util;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
   public class ReportDL : IReportDL
    {
        VolunteerContext vrc;
        public ReportDL(VolunteerContext vrc)
        {
            this.vrc = vrc;
        }
        //get
        public async Task<List<Report>> getReports()
        {
            List<Report> reportL = await vrc.Reports.ToListAsync();
            return reportL;
        }
        //getById
        public async Task<Report> getReporttById(int id)
        {
            Report report = await vrc.Reports.FindAsync(id);
            return report;
        }
        //getByVolunteerId
        public async Task<List<Report>> getByVolunteerId(int id)
        {
            var reports = await vrc.Reports.Include(s => s.Volunteering).Where(s=>s.VolunteeringId==id).ToListAsync();
            return reports;
        }
        //post
        public async Task<int> postReport(Report rt)
        {
            await vrc.Reports.AddAsync(rt);
            return await vrc.SaveChangesAsync();
        }
        //put
        public async Task<Report> putReport(Report rt)
        {
            Report reportToUpdate = await vrc.Reports.FindAsync(rt.Id);
            if (reportToUpdate == null)
                return null;
            vrc.Entry(reportToUpdate).CurrentValues.SetValues(rt);
            await vrc.SaveChangesAsync();
            return rt;
        }
        //delete
        public async Task deleteReport(int id)
        {
            Report rt = await vrc.Reports.FindAsync(id);
            if (rt == null)
                throw new Exception();
            vrc.Reports.Remove(rt);
            await vrc.SaveChangesAsync();
        }

    }
}
