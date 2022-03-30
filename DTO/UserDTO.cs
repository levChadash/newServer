using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
   public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IdNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string CellphoneNumber { get; set; }
        public bool IsAdmin { get; set; }
        public int StudentId { get; set; }
        public int StartYear { get; set; }
        public int GradeNum { get; set; }
        public int ClassNum { get; set; }
        public bool? IsVolunteer { get; set; }
        public int StudentVolunteeringId { get; set; }
        public string VolunteerType { get; set; }
        public string Neihborhood { get; set; }
        public int VolunteeringId { get; set; }


    }
}
