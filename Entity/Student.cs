using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entity
{
    public partial class Student
    {
        public Student()
        {
            Comments = new HashSet<Comment>();
            RegisterStudentId2Navigations = new HashSet<Register>();
            RegisterStudents = new HashSet<Register>();
            StudentComments = new HashSet<StudentComment>();
            StudentYears = new HashSet<StudentYear>();
        }

        public int Id { get; set; }
        public int PersonId { get; set; }
        public int GradeId { get; set; }
        public int NeighborhoodId { get; set; }

        public virtual Grade Grade { get; set; }

        public virtual Neighborhood Neighborhood { get; set; }

        public virtual Person Person { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
  
        public virtual ICollection<Register> RegisterStudentId2Navigations { get; set; }

        public virtual ICollection<Register> RegisterStudents { get; set; }

        public virtual ICollection<StudentComment> StudentComments { get; set; }
   
        public virtual ICollection<StudentYear> StudentYears { get; set; }
    }
}
