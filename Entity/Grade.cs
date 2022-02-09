using Entity;
using System;
using System.Collections.Generic;

#nullable disable





namespace Entity

{
    public partial class Grade
    {
        public Grade()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public int StartYear { get; set; }
        public int GradeNum { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
