using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DL;
using Entity;

namespace BL
{
    public class SpecialProjectBL : ISpecialProjectBL
    {
        ISpecialProjectDL pesachprojectdl;
        public SpecialProjectBL(ISpecialProjectDL pesachprojectdl)
        {
            this.pesachprojectdl = pesachprojectdl;
        }
        //get
        public async Task<List<SpecialProject>> GetPesachProject()
        {

            return await pesachprojectdl.GetPesachProject();
        }
        //getById
        public async Task<SpecialProject> getPesachProjectById(int id)
        {

            return await pesachprojectdl.getPesachProjectById(id);

        }
        //post
        public async Task<int> postPesachProject(SpecialProject psp)
        {

            return await pesachprojectdl.postPesachProject(psp);
        }
        //put
        public async Task<SpecialProject> putPesachProject(SpecialProject psp)
        {

            return await pesachprojectdl.putPesachProject(psp);
        }
        //delete
        public async Task deletePesachProject(int id)
        {

            await pesachprojectdl.DeletePesachProject(id);
        }
    }
}
