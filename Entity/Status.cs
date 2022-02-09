using System;
using System.Collections.Generic;

#nullable disable

namespace Entity
{
    public partial class Status
    {
        public Status()
        {
            Families = new HashSet<Family>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Family> Families { get; set; }
    }
}
