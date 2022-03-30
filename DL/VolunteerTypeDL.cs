using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace DL
{
    public class VolunteerTypeDL : IVolunteerTypeDL
    {
        VolunteerContext vrc;
        public VolunteerTypeDL(VolunteerContext vrc)
        {
            this.vrc = vrc;
        }
        //get
        public async Task<List<VolunteerType>> getVolunteerTypes()
        {
            List<VolunteerType> volunteertypeL = await vrc.VolunteerTypes.ToListAsync();
            return volunteertypeL;
        }
    }
}
