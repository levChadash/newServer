using System;
using System.Collections.Generic;

#nullable disable

namespace Entity
{
    public partial class StudentsVolunteering
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int VolunteeringId { get; set; }

        public virtual Student Student { get; set; }
        public virtual Volunteering Volunteering { get; set; }
    }
}
