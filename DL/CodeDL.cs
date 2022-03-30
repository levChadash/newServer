using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace DL
{
    class CodeDL
    {
        VolunteerContext vrc;
        public CodeDL(VolunteerContext vrc)
        {
            this.vrc = vrc;
        }


    }
}
