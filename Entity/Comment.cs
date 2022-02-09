using System;
using System.Collections.Generic;

#nullable disable

namespace Entity
{
    public partial class Comment
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? StudentId { get; set; }
        public string Comment1 { get; set; }
        public int? NeighborhoodId { get; set; }
        public int? VolunteerTypeId { get; set; }

        public virtual Neighborhood Neighborhood { get; set; }
        public virtual Student Student { get; set; }
        public virtual VolunteerType VolunteerType { get; set; }
    }
}
