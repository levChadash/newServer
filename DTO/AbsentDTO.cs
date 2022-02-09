using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class AbsentDTO
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; }
        public bool Pair { get; set; }
        public string studentName { get; set; }
        public string student2Name { get; set; }
        public string family { get; set; }

    }
}
