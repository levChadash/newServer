using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class ReportDTO
    {
        public int Id { get; set; }
        public int NumOfVisits { get; set; }
        public DateTime SDate { get; set; }
        public string StudentName1 { get; set; }
        public string StudentName2 { get; set; }
        public string Comments { get; set; }

    }
}
