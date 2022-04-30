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
        IstudentsVolunteeringDL volunteeringstudentsdl;
        public VolunteeringBL(IVolunteeringDL volunteeringdl, IstudentsVolunteeringDL volunteeringstudentsdl)
        {
            this.volunteeringdl = volunteeringdl;
            this.volunteeringstudentsdl = volunteeringstudentsdl;
        }

        //get
        public async Task<List<Volunteering>> Get()
        {
            return await volunteeringdl.Get();
        }
        //getbyfamilyid
        //public async Task<List<Volunteering>> GetVolunteeringByFamilyId(int id)
        //{
        //    return await volunteeringdl.GetVolunteeringByFamilyId(id);
        //}


        //post
        public async Task<int> post(Volunteering rg)
        {
            return await volunteeringdl.post(rg);

        }
        //put
        public async Task<Volunteering> put(Volunteering rg)
        {
            return await volunteeringdl.put(rg);
        }
        //delete
        public async Task delete(int id)
        {
            await volunteeringstudentsdl.deleteByVolunteeringId(id);
            await volunteeringdl.delete(id);
        }

    }
}
