using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

#nullable disable

namespace Entity
{
    public partial class Admin
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        [JsonIgnore]
        public virtual Person Person { get; set; }
    }
}
