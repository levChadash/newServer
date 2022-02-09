using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    class PesachProjectDTO
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public DateTime StartRegistration { get; set; }
        public DateTime FinishRegistration { get; set; }
    }
}
