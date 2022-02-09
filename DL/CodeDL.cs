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

        //get neighborhoods
        public async Task<List<Neighborhood>> GetNeighborhoods()
        {
           
            List<Neighborhood> NeighborhoodL = await vrc.Neighborhoods.ToListAsync();
            return NeighborhoodL;
        }
        //get neighborhood by Description
        public async Task<Neighborhood> GetNeighborhoodByDescription(string description)
        {

            Neighborhood  neighborhood =  vrc.Neighborhoods.Single(n=>n.Description == description);
            return neighborhood;
        }
    }
}
