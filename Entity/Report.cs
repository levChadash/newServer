using System;
using System.Collections.Generic;

#nullable disable

namespace Entity
{
    public partial class Report
    {
        public int Id { get; set; }
        public int NumOfVisits { get; set; }
        public DateTime SDate { get; set; }
        public DateTime EDate { get; set; }
        public int VolunteeringId { get; set; }
        public string Comments { get; set; }

        public virtual Volunteering Volunteering { get; set; }
    }
}
