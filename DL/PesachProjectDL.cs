using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Microsoft.EntityFrameworkCore;

namespace DL
{
    public class PesachProjectDL : IPesachProjectDL
    {
        VolunteerContext vrc;
        public PesachProjectDL(VolunteerContext vrc)
        {
            this.vrc = vrc;
        }
        //get
        public async Task<List<PesachProject>> GetPesachProject()
        {
            List<PesachProject> pesachProjects = await vrc.PesachProjects.ToListAsync();
            return pesachProjects;
        }
        //getById
        public async Task<PesachProject> getPesachProjectById(int id)
        {
            PesachProject pesachProjectById = await vrc.PesachProjects.FindAsync(id);
            return pesachProjectById;

        }
        //post
        public async Task<int> postPesachProject(PesachProject psp)
        {
            await vrc.PesachProjects.AddAsync(psp);
            await vrc.SaveChangesAsync();
            return psp.Id;
        }
        //put
        public async Task<PesachProject> putPesachProject(PesachProject psp)
        {
            PesachProject pesachProjectToUpdate = await vrc.PesachProjects.FindAsync(psp.Id);
            if (pesachProjectToUpdate == null)
                return null;
            vrc.Entry(pesachProjectToUpdate).CurrentValues.SetValues(psp);
            await vrc.SaveChangesAsync();
            return psp;
        }
        //delete
        public async Task DeletePesachProject(int id)
        {
            PesachProject pesachProjectToDelete = await vrc.PesachProjects.FindAsync(id);
            if (pesachProjectToDelete == null)
                throw new Exception("pesach project doesnt exist");
            vrc.PesachProjects.Remove(pesachProjectToDelete);
            await vrc.SaveChangesAsync();
        }

    }
}
