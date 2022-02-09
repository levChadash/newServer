using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DL;
using Entity;

namespace BL
{
    public class PesachProjectBL : IPesachProjectBL
    {
        IPesachProjectDL pesachprojectdl;
        public PesachProjectBL(IPesachProjectDL pesachprojectdl)
        {
            this.pesachprojectdl = pesachprojectdl;
        }
        //get
        public async Task<List<PesachProject>> GetPesachProject()
        {

            return await pesachprojectdl.GetPesachProject();
        }
        //getById
        public async Task<PesachProject> getPesachProjectById(int id)
        {

            return await pesachprojectdl.getPesachProjectById(id);

        }
        //post
        public async Task<int> postPesachProject(PesachProject psp)
        {

            return await pesachprojectdl.postPesachProject(psp);
        }
        //put
        public async Task<PesachProject> putPesachProject(PesachProject psp)
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
