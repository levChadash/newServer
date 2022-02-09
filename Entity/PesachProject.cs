using System;
using System.Collections.Generic;

#nullable disable

namespace Entity
{
    public partial class PesachProject
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public DateTime StartRegistration { get; set; }
        public DateTime FinishRegistration { get; set; }
    }
}
