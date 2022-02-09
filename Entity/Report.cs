using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entity
{
    public partial class Report
    {
        public int Id { get; set; }
        public int NumOfVisits { get; set; }
        public DateTime SDate { get; set; }
        public int RegisterId { get; set; }
        public string Comments { get; set; }
        [JsonIgnore]
        public virtual Register Register { get; set; }
    }
}
