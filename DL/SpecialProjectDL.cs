using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace DL
{
    public class SpecialProjectDL : ISpecialProjectDL
    {
        VolunteerContext vrc;
        public SpecialProjectDL(VolunteerContext vrc)
        {
            this.vrc = vrc;
        }
        //get
        public async Task<List<SpecialProject>> GetPesachProject()
        {
            List<SpecialProject> pesachProjects = await vrc.SpecialProjects.ToListAsync();
            return pesachProjects;
        }
        //getById
        public async Task<SpecialProject> getPesachProjectById(int id)
        {
            SpecialProject pesachProjectById = await vrc.SpecialProjects.FindAsync(id);
            return pesachProjectById;

        }
        //post
        public async Task<int> postPesachProject(SpecialProject psp)
        {
            await vrc.SpecialProjects.AddAsync(psp);
            await vrc.SaveChangesAsync();
            return psp.Id;
        }
        //put
        public async Task<SpecialProject> putPesachProject(SpecialProject psp)
        {
            SpecialProject pesachProjectToUpdate = await vrc.SpecialProjects.FindAsync(psp.Id);
            if (pesachProjectToUpdate == null)
                return null;
            vrc.Entry(pesachProjectToUpdate).CurrentValues.SetValues(psp);
            await vrc.SaveChangesAsync();
            return psp;
        }
        //delete
        public async Task DeletePesachProject(int id)
        {
            SpecialProject pesachProjectToDelete = await vrc.SpecialProjects.FindAsync(id);
            if (pesachProjectToDelete == null)
                throw new Exception("pesach project doesnt exist");
            vrc.SpecialProjects.Remove(pesachProjectToDelete);
            await vrc.SaveChangesAsync();
        }

    }
}
