using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class RegisterDTO
    {
        public int Id { get; set; }
        public string StudentName { get; set; }
        public bool Regulary { get; set; }
        public bool OneTime { get; set; }
        public string StudentName2 { get; set; }
        public string Comment { get; set; }
        public string VolunteerType { get; set; }
        public int Year { get; set; }
        public bool Challenging { get; set; }
    }
}
