using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DL;
using Entity;

namespace BL
{
    public class VolunteeringBL : IVolunteeringBL
    {
        IVolunteeringDL volunteeringdl;
        public VolunteeringBL(IVolunteeringDL volunteeringdl)
        {
            this.volunteeringdl = volunteeringdl;
        }

        //get
        public async Task<List<Volunteering>> GetRegister()
        {
            return await volunteeringdl.GetRegister();
        }
        //getbyfamilyid
        //public async Task<List<Volunteering>> GetVolunteeringByFamilyId(int id)
        //{
        //    return await volunteeringdl.GetVolunteeringByFamilyId(id);
        //}


        //post
        public async Task<int> postRegister(Volunteering rg)
        {
            return await volunteeringdl.postRegister(rg);

        }
        //put
        public async Task<Volunteering> putRegister(Volunteering rg)
        {
            return await volunteeringdl.putRegister(rg);
        }
        //delete
        public async Task deleteRegister(int id)
        {
            await volunteeringdl.deleteRegister(id);
        }

    }
}
