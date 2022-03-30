using System;
using System.Collections.Generic;

#nullable disable

namespace Entity
{
    public partial class Student
    {
        public Student()
        {
            StudentsVolunteerings = new HashSet<StudentsVolunteering>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int GradeId { get; set; }
        public int ClassNum { get; set; }
        public bool? IsVolunteer { get; set; }

        public virtual Grade Grade { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<StudentsVolunteering> StudentsVolunteerings { get; set; }
    }
}
