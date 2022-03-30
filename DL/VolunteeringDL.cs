using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    public class VolunteeringDL : IVolunteeringDL
    {
        VolunteerContext vrc;
        public VolunteeringDL(VolunteerContext vrc)
        {
            this.vrc = vrc;
        }
        //get
        public async Task<List<Volunteering>> GetRegister()
        {
            List<Volunteering> registers = await vrc.Volunteerings.ToListAsync();
            return registers;
        }
        //getById
        public async Task<Volunteering> getRegisterById(int id)
        {
            Volunteering RegisterById = await vrc.Volunteerings.FindAsync(id);
            return RegisterById;

        }
        //getByFamilyId
        //public async Task<Volunteering> GetVolunteeringByFamilyId(int id)
        //{

        //}
        //post
        public async Task<int> postRegister(Volunteering rg)
        {
            await vrc.Volunteerings.AddAsync(rg);
            await vrc.SaveChangesAsync();
            return rg.Id;
        }
        //put
        public async Task<Volunteering> putRegister(Volunteering rg)
        {
            Volunteering registerToUpDate = await vrc.Volunteerings.FindAsync(rg.Id);
            if (registerToUpDate == null)
                return null;
            vrc.Entry(registerToUpDate).CurrentValues.SetValues(rg);
            await vrc.SaveChangesAsync();
            return rg;
        }
        //delete
        public async Task deleteRegister(int id)
        {
            Volunteering rt = await vrc.Volunteerings.FindAsync(id);
            if (rt == null)
                throw new Exception();
            vrc.Volunteerings.Remove(rt);
            await vrc.SaveChangesAsync();
        }

    }
}
