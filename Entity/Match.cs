using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entity
{
    public partial class Match
    {
        public Match()
        {
            Absents = new HashSet<Absent>();
        }

        public int Id { get; set; }
        public int FamilyId { get; set; }
        public int RegisterId { get; set; }
        public DateTime DateOfMatch { get; set; }
        [JsonIgnore]
        public virtual Family Family { get; set; }
        [JsonIgnore]
        public virtual Register Register { get; set; }
        [JsonIgnore]
        public virtual ICollection<Absent> Absents { get; set; }
    }
}
