using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
   public interface IReportBL
    {
        Task deleteReport(global::System.Int32 id);
        Task<List<Report>> getReports();
        Task<Report> getReporttById(global::System.Int32 id);
        Task<global::System.Int32> postReport(Report rt);
        Task<Report> putReport(Report rt);
        Task<List<Report>> getByVolunteerId(int id);
    }
}