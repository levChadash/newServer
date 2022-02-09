using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BL
{
    public interface IPesachProjectBL
    {
        Task<List<PesachProject>> GetPesachProject();
        Task<PesachProject> getPesachProjectById(int id);
        Task<int> postPesachProject(PesachProject psp);
        Task<PesachProject> putPesachProject(PesachProject psp);
        Task deletePesachProject(int id);

    }
}