using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
  public  interface IReportDL
    {
        Task deleteReport(int id);
        Task<List<Report>> getReports();
        Task<Report> getReporttById(int id);
        Task<int> postReport(Report rt);
        Task<Report> putReport(Report rt);
        Task<List<Report>> getByVolunteerId(int id);
    }
}