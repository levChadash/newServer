using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entity
{
    public partial class Comment
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? FromUserId { get; set; }
        public int? ToUserId { get; set; }
        public string Comment1 { get; set; }
        public string Neighborhood { get; set; }
        public int? VolunteerTypeId { get; set; }
        [JsonIgnore]
        public virtual User FromUser { get; set; }
        [JsonIgnore]
        public virtual User ToUser { get; set; }
        [JsonIgnore]
        public virtual VolunteerType VolunteerType { get; set; }
    }
}
