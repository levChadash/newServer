using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entity
{
    public partial class Family
    {
        public Family()
        {
            Volunteerings = new HashSet<Volunteering>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string PhoneNumber2 { get; set; }
        public string Email { get; set; }
        public string Neighborhood { get; set; }
        public int VolunteerTypeId { get; set; }
        public bool Approved { get; set; }
        public bool Challenging { get; set; }
        public bool Active { get; set; }
        public bool OneTime { get; set; }
        [JsonIgnore]
        public virtual VolunteerType VolunteerType { get; set; }
        [JsonIgnore]
        public virtual ICollection<Volunteering> Volunteerings { get; set; }
    }
}
