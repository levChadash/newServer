﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Microsoft.EntityFrameworkCore;


namespace DL
{
    public class FamilyDL : IFamilyDL
    {
        VolunteerContext vrc;
        public FamilyDL(VolunteerContext vrc)
        {
            this.vrc = vrc;
        }
        //get
        public async Task<List<Family>> GetFamilies()
        {
            List<Family> familyL = await vrc.Families.Include(s=>s.VolunteerType).ToListAsync();
            return familyL;
        }
        public async Task<List<Family>> GetNotSetFamilies()
        {
            List<Family> familyL = await vrc.Families.Where(f => f.Volunteerings.Count == 0).Include(s => s.VolunteerType).ToListAsync();
            return familyL;
        }
        //getById
        public async Task<Family> GetFamilyById(int id)
        {
            Family family = await vrc.Families.Where(s=>s.Id==id).Include(s => s.VolunteerType).FirstOrDefaultAsync();
            return family;
        }
        //post
        public async Task<int> PostFamily(Family new_family)
        {
            await vrc.Families.AddAsync(new_family);
            await vrc.SaveChangesAsync();
            return new_family.Id;
        }
        //put
        public async Task<Family> PutFamily(Family family)
        {
            Family familyToUpDate = await vrc.Families.Where(s => s.Id == family.Id).Include(s => s.VolunteerType).FirstOrDefaultAsync();
            if (familyToUpDate == null)
            {
                return null;
            }
            vrc.Entry(familyToUpDate).CurrentValues.SetValues(family);

            await vrc.SaveChangesAsync();
            return family;
        }
        //delete
        public async Task DeleteFamily(int id)
        {
            Family fm = await vrc.Families.FindAsync(id);
            if (fm == null)
                throw new Exception();
            vrc.Families.Remove(fm);
            await vrc.SaveChangesAsync();
        }
        
    }
}
