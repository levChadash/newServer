using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class AbsentDL : IAbsentDL
    {
        VolunteerContext vrc;
        public AbsentDL(VolunteerContext vrc)
        {
            this.vrc = vrc;
        }
        //get
        public async Task<List<Absent>> Get()
        {
            List<Absent> absents = await vrc.Absents.ToListAsync();
            return absents;
        }
        public async Task<int> postAbsent(Absent abs)
        {
            await vrc.Absents.AddAsync(abs);
            await vrc.SaveChangesAsync();
            return abs.Id;
        }





    }
}
