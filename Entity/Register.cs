using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entity
{
    public partial class Register
    {
        public Register()
        {
            Matches = new HashSet<Match>();
            Reports = new HashSet<Report>();
        }

        public int Id { get; set; }
        public int StudentId { get; set; }
        public bool Regulary { get; set; }
        public bool OneTime { get; set; }
        public int StudentId2 { get; set; }
        public string Comment { get; set; }
        public int VolunteerTypeId { get; set; }
        public int Year { get; set; }
        public bool Challenging { get; set; }
        public int? NeihborhoodId { get; set; }
        [JsonIgnore]
        public virtual Neighborhood Neihborhood { get; set; }
        [JsonIgnore]
        public virtual Student Student { get; set; }
        [JsonIgnore]
        public virtual Student StudentId2Navigation { get; set; }
        [JsonIgnore]
        public virtual VolunteerType VolunteerType { get; set; }
        [JsonIgnore]
        public virtual ICollection<Match> Matches { get; set; }
        [JsonIgnore]
        public virtual ICollection<Report> Reports { get; set; }
    }
}
