using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entity
{
    public partial class Volunteering
    {
        public Volunteering()
        {
            Absents = new HashSet<Absent>();
            Reports = new HashSet<Report>();
            StudentsVolunteerings = new HashSet<StudentsVolunteering>();
        }

        public int Id { get; set; }
        public int VolunteerTypeId { get; set; }
        public int? FamilyId { get; set; }
        public DateTime DateOfMatch { get; set; }
        public string Comment { get; set; }
        public int Year { get; set; }
        public bool Challenging { get; set; }
        public string Neighborhood { get; set; }
        [JsonIgnore]
        public virtual Family Family { get; set; }
        [JsonIgnore]
        public virtual VolunteerType VolunteerType { get; set; }
        [JsonIgnore]
        public virtual ICollection<Absent> Absents { get; set; }
        [JsonIgnore]
        public virtual ICollection<Report> Reports { get; set; }
        [JsonIgnore]
        public virtual ICollection<StudentsVolunteering> StudentsVolunteerings { get; set; }
    }
}
