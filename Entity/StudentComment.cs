using System;
using System.Collections.Generic;

#nullable disable

namespace Entity
{
    public partial class StudentComment
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string Comment { get; set; }

        public virtual Student Student { get; set; }
    }
}
