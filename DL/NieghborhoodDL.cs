using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entity;
using System.Threading.Tasks;

namespace DL
{
    public class NieghborhoodDL : INieghborhoodDL
    {
        VolunteerContext vrc;
        public NieghborhoodDL(VolunteerContext vrc)
        {
            this.vrc = vrc;
        }

        //getBynum
        public async Task<int> GetNieghborhoodId(string name)
        {
            Neighborhood nieghborhood = await vrc.Neighborhoods.Where(s => s.Description == name).FirstOrDefaultAsync();
            return nieghborhood.Id;
        }

    }
}
