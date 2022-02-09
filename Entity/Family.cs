using System;
using System.Collections.Generic;

#nullable disable

namespace Entity
{
    public partial class Family
    {
        public Family()
        {
            Matches = new HashSet<Match>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumber2 { get; set; }
        public string Email { get; set; }
        public int NeighborhoodId { get; set; }
        public int VolunteerTypeId { get; set; }
        public bool Approved { get; set; }
        public bool Challenging { get; set; }
        public int StatusId { get; set; }

        public virtual Neighborhood Neighborhood { get; set; }
        public virtual Status Status { get; set; }
        public virtual VolunteerType VolunteerType { get; set; }
        public virtual ICollection<Match> Matches { get; set; }
    }
}
