using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public   class VolunteeringDTO
    {
        public int Id { get; set; }
        public string VolunteerType{ get; set; }
        public string? FamilyName { get; set; }
        public DateTime DateOfMatch { get; set; }
        public string Comment { get; set; }
        public int Year { get; set; }
        public bool Challenging { get; set; }
        public string Neihborhood { get; set; }
    }
}
