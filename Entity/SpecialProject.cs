using System;
using System.Collections.Generic;

#nullable disable

namespace Entity
{
    public partial class SpecialProject
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public DateTime StartRegistration { get; set; }
        public DateTime FinishRegistration { get; set; }
        public int VolunteerTypeId { get; set; }

        public virtual VolunteerType VolunteerType { get; set; }
    }
}
