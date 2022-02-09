using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DL;
using Entity;

namespace BL
{

    public class FamilyBL : IFamilyBL
    {
        IFamilyDL familydl;
        public FamilyBL(IFamilyDL familydl)
        {
            this.familydl = familydl;
        }
        //get
        public async Task<List<Family>> GetFamilies()
        {
            return await familydl.GetFamilies();
        }
        //getById
        public async Task<Family> GetFamilyById(int id)
        {
            return await familydl.GetFamilyById(id);
        }
        // post

        public async Task<int> PostFamily(Family new_family)
        {
            return await familydl.PostFamily(new_family);

        }
        //put
        public async Task<Family> PutFamily(Family family)
        {
            return await familydl.PutFamily(family);

        }
        //delete
        public async Task DeleteFamily(int id)
        {
            await familydl.DeleteFamily(id);
        }
    }
}
