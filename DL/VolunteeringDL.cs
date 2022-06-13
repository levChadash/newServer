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
        public async Task<List<Volunteering>> Get()
        {
            List<Volunteering> registers = await vrc.Volunteerings.ToListAsync();
            return registers;
        }
        //get by id
        public async Task<Volunteering> GetById(int id)
        {
            Volunteering v = await vrc.Volunteerings.Where(s => s.Id == id).FirstOrDefaultAsync();
            return v;
        }



        //get not  set volunteerung
        public async Task<List<Volunteering>> GetNotSet()
        {
            List<Volunteering> registers = await vrc.Volunteerings.Where(s => s.FamilyId == null).Include(s => s.VolunteerType).Include(s => s.Family).ToListAsync();
            return registers;
        }

        //getById
        public async Task<Volunteering> getById(int id)
        {
            Volunteering RegisterById = await vrc.Volunteerings.FindAsync(id);
            return RegisterById;

        }
        //getByFamilyId
        //public async Task<Volunteering> GetVolunteeringByFamilyId(int id)
        //{

        //}
        //post
        public async Task<int> post(Volunteering rg)
        {
            await vrc.Volunteerings.AddAsync(rg);
            await vrc.SaveChangesAsync();
            return rg.Id;
        }
        //put
        public async Task<Volunteering> put(Volunteering rg)
        {
            Volunteering registerToUpDate = await vrc.Volunteerings.FindAsync(rg.Id);
            if (registerToUpDate == null)
                return null;
            vrc.Entry(registerToUpDate).CurrentValues.SetValues(rg);
            await vrc.SaveChangesAsync();
            return rg;
        }
        //delete
        public async Task delete(int id)
        {
            Volunteering rt = await vrc.Volunteerings.FindAsync(id);
            if (rt == null)
                throw new Exception();
            vrc.Volunteerings.Remove(rt);
            await vrc.SaveChangesAsync();
        }
        public async Task<List<Volunteering>> getByFamilyId(int id)
        {
            List<Volunteering> lv = await vrc.Volunteerings.Where(v=>v.FamilyId==id).ToListAsync();
            if (lv == null)
                throw new Exception();
            return lv;
            
        }

    }
}
