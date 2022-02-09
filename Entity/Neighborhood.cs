using System;
using System.Collections.Generic;

#nullable disable

namespace Entity
{
    public partial class Neighborhood
    {
        public Neighborhood()
        {
            Comments = new HashSet<Comment>();
            Families = new HashSet<Family>();
            Registers = new HashSet<Register>();
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Family> Families { get; set; }
        public virtual ICollection<Register> Registers { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
