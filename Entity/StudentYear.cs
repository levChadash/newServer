using System;
using System.Collections.Generic;

#nullable disable

namespace Entity
{
    public partial class StudentYear
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int Year { get; set; }
        public int ClassNumber { get; set; }

        public virtual Student Student { get; set; }
    }
}
