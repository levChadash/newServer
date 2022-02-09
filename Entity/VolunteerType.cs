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
            Registers = new HashSet<Register>();
        }

        public int Id { get; set; }
        public string Dscription { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Family> Families { get; set; }
        public virtual ICollection<Register> Registers { get; set; }
    }
}
