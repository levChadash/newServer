using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entity
{
    public partial class VolunteerType
    {
        public VolunteerType()
        {
            Comments = new HashSet<Comment>();
            Families = new HashSet<Family>();
            SpecialProjects = new HashSet<SpecialProject>();
            Volunteerings = new HashSet<Volunteering>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        [JsonIgnore]
        public virtual ICollection<Comment> Comments { get; set; }
        [JsonIgnore]
        public virtual ICollection<Family> Families { get; set; }
        [JsonIgnore]
        public virtual ICollection<SpecialProject> SpecialProjects { get; set; }
        [JsonIgnore]
        public virtual ICollection<Volunteering> Volunteerings { get; set; }
    }
}
