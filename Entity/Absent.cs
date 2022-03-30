using System;
using System.Collections.Generic;

#nullable disable

namespace Entity
{
    public partial class Absent
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Reason { get; set; }
        public bool Pair { get; set; }
        public int VolunteeringId { get; set; }

        public virtual Volunteering Volunteering { get; set; }
    }
}
