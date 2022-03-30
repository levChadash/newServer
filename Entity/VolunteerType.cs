using System;
using System.Collections.Generic;

#nullable disable

namespace Entity
{
    public partial class VolunteerType
    {
        public VolunteerType()
        {
            Comments = new HashSet<Comment>();
            Families = new HashSet<Family>();
            SpecialProjects = new HashSet<SpecialProject>();
            Volunteerings = new HashSet<Volunteering>();
        }

        public int Id { get; set; }
        public string Type { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Family> Families { get; set; }
        public virtual ICollection<SpecialProject> SpecialProjects { get; set; }
        public virtual ICollection<Volunteering> Volunteerings { get; set; }
    }
}
