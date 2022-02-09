using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IPesachProjectDL
    {
        Task<List<PesachProject>> GetPesachProject();
        Task<PesachProject> getPesachProjectById(int id);
        Task<int> postPesachProject(PesachProject psp);
        Task<PesachProject> putPesachProject(PesachProject psp);
        Task DeletePesachProject(int id);
    }
}