using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class MatchDTO
    {
        public int Id { get; set; }
        public string FamilyName { get; set; }
        public string student1 { get; set; }
        public string student2 { get; set; }
        public DateTime DateOfMatch { get; set; }
    }
}
